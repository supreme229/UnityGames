using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip[] myMusic;
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
    private void playRandomMusic()
    {
        audio.clip = myMusic[Random.Range(0, myMusic.Length)];
        audio.Play();
        StartCoroutine(Fader.StartFade(audio, 5f, AudioListener.volume));
    }
}
