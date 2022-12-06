using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;
    private Vector3 velocity = Vector3.zero;
    private int playerLane = 0;
    private int nextLane = 0;
    public float forwardSpeed;
    private float laneDistance = 3.1f;
    private float gravity = -12f;
    private float jumpHeight = 3f;
    private bool isSliding = false;
    private float scoreBorder = 5f;
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R) && !GameManager.getGameOn())
        {
            animator.SetTrigger("TrRun");
            velocity.z = forwardSpeed;
            GameManager.setGameOn(true);
        }
        else if(GameManager.getGameOn())
        {
            if (transform.position.z > scoreBorder)
            {
                GameManager.updateScore(1);
                scoreBorder += 5f;
            }

            if (controller.isGrounded && velocity.y < 0)
                velocity.y = -2f;

            if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded && !isSliding)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * 2 * -gravity);
            }

            if (controller.isGrounded && !isSliding)
            {
                animator.SetBool("Jump", false);
                controller.height = 1.75f;
            }
            else if (!isSliding)
            {
                animator.SetBool("Jump", true);
                controller.height = 1.3f;
            }

            if (Input.GetKeyDown(KeyCode.S) && controller.isGrounded && !isSliding)
            {
                StartCoroutine(Slide());
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                if(playerLane != -1)
                    nextLane--;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (playerLane != 1)
                    nextLane++;
            }

            Vector3 newPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
            playerLane = nextLane;
            newPosition.x = playerLane * laneDistance;

            if (transform.position != newPosition)
            {
                Vector3 difference = newPosition - transform.position;
                Vector3 moveDirection = difference.normalized * 10 * Time.deltaTime;
                if (moveDirection.sqrMagnitude < difference.sqrMagnitude)
                    controller.Move(moveDirection);
                else
                    controller.Move(difference);
            }

        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("Slide", true);

        yield return new WaitForSeconds(0.25f);

        controller.center = new Vector3(0.2f, 0.3f, 0);
        controller.height = 0.3f;

        yield return new WaitForSeconds(0.25f);

        controller.center = new Vector3(0.2f, 0.35f, 0);
        controller.height = 0.6f;

        yield return new WaitForSeconds(0.3f);

        controller.center = new Vector3(0.2f, 0.35f, 0);
        controller.height = 0.7f;

        yield return new WaitForSeconds(1.15f - 0.8f);

        animator.SetBool("Slide", false);

        isSliding = false;

        controller.center = new Vector3(0f, 0.9f, 0f);
        controller.height = 1.75f;
    }
}
