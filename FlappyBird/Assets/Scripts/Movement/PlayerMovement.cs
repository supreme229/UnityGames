using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 direction;
    private Animator animator;
    private bool canMove = true;
    public float gravity = -9.6f;
    public float strength = 5f;
    private void Start()
    {
        animator = GetComponent<Animator>();        
    }

    private void Update()
    {
        if (canMove)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction = Vector3.up * strength;
            }

            direction.y += gravity * Time.deltaTime;
            transform.position += direction * Time.deltaTime;
        }
    }
    public void disableMovement()
    {
        canMove = false;
    }
    public void enableMovement()
    {
        canMove = true;
    }
    public void gameoverAnimation()
    {
        animator.SetTrigger("TrGameover");
    }
}
