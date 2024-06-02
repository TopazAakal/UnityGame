using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 6;
    public float jump;
    public float gravity = 15;
    public Vector3 moveDirection;
    public Animator animator;
    public CharacterController controller;
    public float fallThreshold = -10f; 
    public Vector3 respawnPoint = new Vector3(0, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical")*speed*Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal")*speed * Time.deltaTime;

        moveDirection = new Vector3(horizontal, jump*Time.deltaTime, vertical);
        moveDirection = transform.TransformDirection(moveDirection);

        if (moveDirection.z != 0 )
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetInteger("move", 2);
                speed = 10;
            }
            else
            {
                animator.SetInteger("move", 1);
                speed = 6;
            }
        }
        else
        {
            animator.SetInteger("move", 0);
        }

        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                jump = 10;
                animator.SetInteger("move", 3);
            }
        }
        else
        {
            jump-=gravity*Time.deltaTime;
        }

        controller.Move(moveDirection);

        // Check if the player has fallen off the ground
        if (transform.position.y < fallThreshold)
        {
            BackToGround();
        }
    }

    void BackToGround()
    {
        controller.enabled = false; 
        transform.position = respawnPoint;
        controller.enabled = true; 

        moveDirection.y = 0;
        jump = 0;
    }
}
