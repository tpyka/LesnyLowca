using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{   
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D animalRigidbody;

    [SerializeField] bool isBoss = false;




    void Start()
    {
        animalRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isBoss)
        {
            animalRigidbody.velocity = new Vector2(moveSpeed, 0.05f);
        } else
        {
            animalRigidbody.velocity = new Vector2(moveSpeed, 0f);
        }
        
    }

    void OnTriggerExit2D(Collider2D other) {
        moveSpeed = -moveSpeed;
        zmienKierunekRuchu();
    }


    void zmienKierunekRuchu()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(animalRigidbody.velocity.x)), 1f);
    }
}
