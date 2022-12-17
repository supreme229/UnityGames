using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private CharacterController controller;
    private Canvas gameoverCanvas;
    private AudioSource audioSource;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        gameoverCanvas = GameObject.FindGameObjectWithTag("GameoverUI").GetComponent<Canvas>();
        gameoverCanvas.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag == "Obstacle")
        {
            AudioManager.Instance.playDieSound(audioSource);
            gameoverCanvas.gameObject.SetActive(true);
            Time.timeScale = 0f;
            GameManager.setGameOn(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bonus")
        {
            Destroy(other.gameObject);
            AudioManager.Instance.playCoinPickupSound(audioSource);
            GameManager.updateScore(3);
        }
    }
}
