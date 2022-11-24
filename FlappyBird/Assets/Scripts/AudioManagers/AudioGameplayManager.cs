using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGameplayManager : MonoBehaviour
{
    private AudioSource audio;
    private float gameplayMusicVolume = 0.5f;
    public AudioClip[] gameplayMusic;
    public AudioClip gameoverSound;
    public AudioClip pointSound;
    public AudioClip coinSound;
    private bool isNotFading = true;

    private void Awake()
    {
        audio = FindObjectOfType<AudioSource>();    
    }
    private void Start()
    {
        playRandomMusic();
    }
    private void Update()
    {
        if (!GameVariables.gameIsOver())
        {
            if (!audio.isPlaying)
            {
                playRandomMusic();
                isNotFading = true;
            }
            if (audio.clip.length - audio.time <= 6f && isNotFading)
            {
                isNotFading = false;
                StartCoroutine(Fader.StartFade(audio, 5f, 0f));
            }
        }
    }
    private void playRandomMusic()
    {
        audio.clip = gameplayMusic[Random.Range(0, gameplayMusic.Length)];
        audio.Play();
        StartCoroutine(Fader.StartFade(audio, 5f, gameplayMusicVolume));
    }
    public void playGameoverSound()
    {
        audio.clip = gameoverSound;
        audio.Play();
    }
    public void playPointSound()
    {
        audio.PlayOneShot(pointSound);
    }
    public void playCoinSound()
    {
        audio.PlayOneShot(coinSound);
    }
}
