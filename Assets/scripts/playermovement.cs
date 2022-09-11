using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 20;
    
    float horizontalMove = 0f;

    bool jump = false;

    bool crouch = false;

    public Rigidbody2D rb;

    Vector2 pushDown;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pushDown = new Vector2(0f, -1f);
        
    }
    void Update()
    {
        playerBoundaries();
        playerControl();
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    private void playerControl()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetButtonDown("crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("crouch"))
        {
            crouch = false;
        }
        if (Input.GetButtonDown("crouch")
           &&
            CharacterController2D.m_Grounded == true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 1);

        }
    }

    private void playerBoundaries()
    {
        if (transform.position.x < 0)
        {
            transform.position = new Vector3(20, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 20)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        if (transform.position.y > 6.2)
        {
            rb.AddForce(pushDown * runSpeed);
        }
        if (transform.position.y > 6.4)
        {
            transform.position = new Vector3(transform.position.x, 6.4f, transform.position.z);
        }
    }

}
