using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float runSpeed = 7;
    public float rotationSpeed = 250;

    public Animator animator;
    private float x,y;
    public Rigidbody rb;
    public float jumpHeight = 2;
    public Transform groundCheck ;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    bool IsGrounded;

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        transform.Rotate(0, x * Time.deltaTime *rotationSpeed,0);   
        transform.Translate(0,0, y*Time.deltaTime *runSpeed);
        animator.SetFloat("VelX",x);
        animator.SetFloat("VelY",y);



        IsGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(Input.GetKey("space") && IsGrounded)
        {
            animator.Play("Jump");
            Invoke("Jump",0.1f);
        }


    }
    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);

    }
}
