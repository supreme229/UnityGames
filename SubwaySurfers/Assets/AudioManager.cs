using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private AudioClip coinPickup;
    private AudioClip jump;
    private AudioClip slide;
    private AudioClip die;
    private AudioClip[] landingSounds = new AudioClip[5];

    void Start()
    {
        coinPickup = Resources.Load<AudioClip>("Audio/Sounds/CoinPickup");
        jump = Resources.Load<AudioClip>("Audio/Sounds/Jump");
        slide = Resources.Load<AudioClip>("Audio/Sounds/Slide");
        die = Resources.Load<AudioClip>("Audio/Sounds/Die");
        landingSounds[0] = Resources.Load<AudioClip>("Audio/Sounds/Land1");
        landingSounds[1] = Resources.Load<AudioClip>("Audio/Sounds/Land2");
        landingSounds[2] = Resources.Load<AudioClip>("Audio/Sounds/Land3");
        landingSounds[3] = Resources.Load<AudioClip>("Audio/Sounds/Land4");
        landingSounds[4] = Resources.Load<AudioClip>("Audio/Sounds/Land5");
    }

    public void playCoinPickupSound(AudioSource audioSource)
    {
        audioSource.PlayOneShot(coinPickup);
    }
    public void playJumpSound(AudioSource audioSource)
    {
        audioSource.PlayOneShot(jump);
    }
    public void playSlideSound(AudioSource audioSource)
    {
        audioSource.PlayOneShot(slide);
    }
    public void playLandingSound(AudioSource audioSource)
    {
        audioSource.PlayOneShot(landingSounds[Random.Range(0,5)]);
    }
    public void playDieSound(AudioSource audioSource)
    {
        audioSource.PlayOneShot(die);
    } 
}
