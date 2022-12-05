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
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
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

        if (Input.GetKeyDown(KeyCode.G) && controller.isGrounded)
        {
            StartCoroutine(Slide());
        }

        velocity.y += gravity * Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("TrRun");
            velocity.z = forwardSpeed;
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

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        playerLane = nextLane;
        targetPosition.x = playerLane * laneDistance;

        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 10 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.sqrMagnitude)
                controller.Move(moveDir);
            else
                controller.Move(diff);
        }


        controller.Move(velocity * Time.deltaTime);
    }

    private IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("Slide", true);

        yield return new WaitForSeconds(0.25f / Time.timeScale);

        controller.center = new Vector3(0.2f, 0.3f, 0);
        controller.height = 0.3f;

        yield return new WaitForSeconds((0.25f) / Time.timeScale);

        controller.center = new Vector3(0.2f, 0.3f, 0);
        controller.height = 1f;

        yield return new WaitForSeconds((1.15f - 0.25f) / Time.timeScale);

        animator.SetBool("Slide", false);

        isSliding = false;

        controller.center = new Vector3(0f, 0.9f, 0f);
        controller.height = 1.75f;
    }
}
