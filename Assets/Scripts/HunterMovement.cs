using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HunterMovement : MonoBehaviour
{
    [SerializeField] float ruchSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float wspinaczkaSpeed = 5f;
    [SerializeField] Vector2 noMovement = new Vector2 (0f, 0f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;

    LevelManager levelManager;
    AudioPlayer audioPlayer;
    [SerializeField] ParticleSystem hitEffect;

    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    Vector2 moveInput;
    Rigidbody2D hunterRigidbody;
    Animator hunterAnimator;
    CapsuleCollider2D hunterBodyCollider;
    BoxCollider2D bottomCollider;
    float startingGravity;

    bool isAlive = true;

    void Start()
    {
        hunterRigidbody = GetComponent<Rigidbody2D>();
        hunterAnimator = GetComponent<Animator>();
        hunterBodyCollider = GetComponent<CapsuleCollider2D>();
        bottomCollider = GetComponent<BoxCollider2D>();
        startingGravity = hunterRigidbody.gravityScale;
    }

    void Update()
    {
        if (!isAlive) { return; }
        Run();
        ObrocSprite();
        ClimbTree();
        Die();
    }

    void OnFire(InputValue value)
    {
        if (!isAlive) { return; }
        audioPlayer.PlayShootingClip();
        Instantiate(bullet, gun.position, transform.rotation);
    }
    
    void OnMove(InputValue value)
    {
        if (!isAlive) { return; }
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!isAlive) { return; }
        if (!bottomCollider.IsTouchingLayers(LayerMask.GetMask("Platformy"))) { return;}
        
        if(value.isPressed)
        {  
            hunterRigidbody.velocity += new Vector2 (0f, jumpSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "SpeedSlowdown")
        {
            ruchSpeed = 1;
            Debug.Log("You're slow man!");
            Destroy(otherCollider.gameObject);
           audioPlayer.PlayCoughClip();
        }

        if (otherCollider.tag == "SpeedAntidote")
        {
            ruchSpeed = 10f;
            Debug.Log("You're fast again man!");
            Destroy(otherCollider.gameObject);
            audioPlayer.PlayAidkitClip();
        }
    }

    void Run()
    {
        Vector2 hunterSzybkoscPoruszania = new Vector2 (moveInput.x * ruchSpeed, hunterRigidbody.velocity.y);
        hunterRigidbody.velocity = hunterSzybkoscPoruszania;

        bool czymaPoziomaSpeed = Mathf.Abs(hunterRigidbody.velocity.x) > Mathf.Epsilon;
        hunterAnimator.SetBool("isRunning", czymaPoziomaSpeed);

    }

    void ObrocSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(hunterRigidbody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(hunterRigidbody.velocity.x), 1f);
        }
    }

    void ClimbTree()
    {
        if (!bottomCollider.IsTouchingLayers(LayerMask.GetMask("Wspinaczki"))) 
        { 
            hunterRigidbody.gravityScale = startingGravity;
            hunterAnimator.SetBool("isClimbing", false);
        
            return;
        }
        
        Vector2 climbVelocity = new Vector2 (hunterRigidbody.velocity.x, moveInput.y * wspinaczkaSpeed);
        hunterRigidbody.velocity = climbVelocity;
        hunterRigidbody.gravityScale = 0f;

        bool playerHasVerticalSpeed = Mathf.Abs(hunterRigidbody.velocity.y) > Mathf.Epsilon;
        hunterAnimator.SetBool("isClimbing", playerHasVerticalSpeed);
        
    }

    void Die()
    {
        if (hunterBodyCollider.IsTouchingLayers(LayerMask.GetMask("Wrogowie", "Przeszkody")))
        {
            isAlive = false;
            PlayHitEffect();
            hunterAnimator.SetTrigger("Dying");
            hunterRigidbody.velocity = noMovement;
            audioPlayer.PlayDyingClip();
            levelManager.LoadEkranKoncowy();
        }
    }

    void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

}
