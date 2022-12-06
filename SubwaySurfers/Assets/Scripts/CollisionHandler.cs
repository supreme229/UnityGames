using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private CharacterController controller;
    private Canvas gameoverCanvas;
    private AudioSource audioSource;
    private Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();

    void Start()
    {
        controller = GetComponent<CharacterController>();
        gameoverCanvas = GameObject.FindGameObjectWithTag("GameoverUI").GetComponent<Canvas>();
        gameoverCanvas.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        clips["coin-pickup"] = Resources.Load<AudioClip>("Audio/Sounds/CoinPickup");
    }

    void Update()
    {    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag == "Obstacle")
        {
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
            audioSource.PlayOneShot(clips["coin-pickup"]);
            GameManager.updateScore(3);
        }
    }
}
