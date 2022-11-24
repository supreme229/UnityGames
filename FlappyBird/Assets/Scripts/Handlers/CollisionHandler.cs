using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private GameUIManager gameUIManager;
    private AudioGameplayManager audioGameplayManager;
    private bool isCoroutineExecuting = false;
    private float edgeBottom, edgeTop;
    private delegate void Task();

    private void Awake()
    {
        audioGameplayManager = FindObjectOfType<AudioGameplayManager>();
        gameUIManager = FindObjectOfType<GameUIManager>();
        edgeBottom = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, Camera.main.nearClipPlane)).y;
        edgeTop = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, Camera.main.nearClipPlane)).y;
    }
    
    private IEnumerator ExecuteAfterTime(float time, Task task)
    {
        if (isCoroutineExecuting)
        {
            yield break;
        }
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        task();
        isCoroutineExecuting = false;
    }

    private void Update()
    {
        if (transform.position.y < edgeBottom - 1f || transform.position.y > edgeTop + 1f)
        {
            if (!GameVariables.gameIsOver())
            {
                GameVariables.setGameOn(false);
                PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
                playerMovement.disableMovement();
                GameVariables.updateGameover(true);
                audioGameplayManager.playGameoverSound();
            }

            FindObjectOfType<SceneLoader>().LoadNextScene();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!GameVariables.gameIsOver())
        {
            if(other.gameObject.tag == "Point")
            {
                GameVariables.updateScore(1);
                audioGameplayManager.playPointSound();
                gameUIManager.setGUIScore(GameVariables.getScore());
            }

            if(other.gameObject.tag == "ObstaclePart")
            {
                GameVariables.setGameOn(false);

                PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
                playerMovement.disableMovement();

                GameVariables.updateGameover(true);
                audioGameplayManager.playGameoverSound();

                playerMovement.gameoverAnimation();

                StartCoroutine(ExecuteAfterTime(2f, () =>
                {
                    Rigidbody playerRig = GetComponent<Rigidbody>();
                    playerRig.useGravity = true;
                    playerRig.isKinematic = false;
                }));
            }

            if(other.gameObject.tag == "Bonus")
            {
                GameVariables.updateScore(2);
                audioGameplayManager.playCoinSound();
                gameUIManager.setGUIScore(GameVariables.getScore());
                Destroy(other.gameObject);
            }
        }
    }
}
