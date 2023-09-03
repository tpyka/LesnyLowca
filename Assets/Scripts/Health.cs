using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool isBoss = false;
    LevelManager levelManager;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Pocisk")
        {
            Debug.Log("trafilo");
            TakeDamage();
            PlayHitEffect();
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

    void TakeDamage()
    {
        health -= 10;
        if (health <= 0)
        {
            if (isBoss)
            {
                levelManager.LoadPoBoss();
            } else
            {
                Destroy(gameObject);
            }
           
        }
    }
}