using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;
    
    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 5f;

    [Header("Death")]
    [SerializeField] AudioClip deathClip;
    [SerializeField] [Range(0f, 1f)] float deathVolume = 5f;

    [Header("Finishing Level")]
    [SerializeField] AudioClip levelFinishClip;
    [SerializeField] [Range(0f, 1f)] float levelFinishVolume = 20f;

    [Header("Jump sound")]
    [SerializeField] AudioClip jumpClip;
    [SerializeField] [Range(0f, 1f)] float jumphVolume = 5f;

    [Header("Coughing sound")]
    [SerializeField] AudioClip coughClip;
    [SerializeField] [Range(0f, 1f)] float coughVolume = 5f;

    [Header("Healthy sound")]
    [SerializeField] AudioClip healthyClip;
    [SerializeField] [Range(0f, 1f)] float healthyVolume = 5f;

    [Header("Boom sound")]
    [SerializeField] AudioClip boomClip;
    [SerializeField] [Range(0f, 1f)] float boomVolume = 5f;


    public void PlayBoomClip()
    {
        PlayClip(boomClip, boomVolume);
    }

    public void PlayCoughClip()
    {
        PlayClip(coughClip, coughVolume);
    }


    public void PlayAidkitClip()
    {
        PlayClip(healthyClip, healthyVolume);
    }
   
    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }

    public void PlayDyingClip()
    {
        PlayClip(deathClip, deathVolume);
    }

    public void PlayLevelFinishClip()
    {
        PlayClip(levelFinishClip, levelFinishVolume);
    }

    public void PlayJumpingClip()
    {
        PlayClip(jumpClip, jumphVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }

}
