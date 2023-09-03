using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    Rigidbody2D myRigidbody;
    HunterMovement player;
    float xSpeed;

    LevelManager levelManager;
    AudioPlayer audioPlayer;

    [SerializeField] ParticleSystem hitEffect;


    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
     
    }
   

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<HunterMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
        
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2 (xSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "TNT")
        {
            Destroy(other.gameObject);
            PlayHitEffect();
            audioPlayer.PlayBoomClip();
            Debug.Log("next level");
            levelManager.LoadPoTNT();
            //  Destroy(other.gameObject);
        }

        if (other.tag == "Enemy")
        {
           audioPlayer.PlayDamageClip();
            PlayHitEffect();

            //  Destroy(other.gameObject);


        }
        Destroy(gameObject);

    
    }

    void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }


    void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject);    
   }

}
