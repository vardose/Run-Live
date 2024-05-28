using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public TMP_Text velocity_text;
    
    [Header("Movement")] public float moveSpeed = 10f;
    public float jumpForce = 10f ;

    [Header("Ground Check")] public float playerHeight;
    public LayerMask whatIsGround;
    private bool grounded;
    private bool jumpedInAir;

    public Transform orientation;

    private Vector2 moveInput;
    private Vector3 moveDir;
    private float gravity = -1f;
    private Rigidbody rb;

    private ControlMap controlMap;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        controlMap = new ControlMap();
        controlMap.Player.Enable();
        rb = GetComponent<Rigidbody>();
        jumpedInAir = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = orientation.rotation;
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
        moveInput = controlMap.Player.Move.ReadValue<Vector2>();
        if (grounded)
        {
            jumpedInAir = false;
        }
        else
        {
            rb.AddForce(transform.up * gravity, ForceMode.Force);
        }
        if (controlMap.Player.Jump.triggered) {
            Jump();
        }
        velocity_text.text = "Speed : "+ Math.Round(rb.velocity.magnitude);
    }

    private void FixedUpdate()
    {
        if (moveInput != Vector2.zero)
        {
            MovePlayer();
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }

    private void MovePlayer()
    {
        moveDir = orientation.forward * moveInput.y + orientation.right * moveInput.x;
        rb.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void Jump()
    {
        if (!grounded && jumpedInAir )
        {
            return;
        }
        else if (!jumpedInAir)
        {
            rb.AddForce( transform.up * jumpForce, ForceMode.Impulse);
            jumpedInAir = true;
            return;
        }
        rb.AddForce( transform.up * jumpForce, ForceMode.Impulse);
    }
}
