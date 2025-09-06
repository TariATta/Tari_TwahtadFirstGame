using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingPlayerInput : MonoBehaviour
{
    private MyInputAction inputActions;
    private Vector2 moveInput;

    private Rigidbody rb;
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private bool isGrounded = true;

    private void Awake()
    {
        inputActions = new MyInputAction();
    }

    private void OnEnable()
    {
        inputActions.Jelly.Enable();

        inputActions.Jelly.Movement.performed += OnMovePerformed;
        inputActions.Jelly.Movement.canceled += OnMoveCanceled;
        inputActions.Jelly.Jump.performed += OnJumpPerformed;
    }

    private void OnDisable()
    {
        inputActions.Jelly.Movement.performed -= OnMovePerformed;
        inputActions.Jelly.Movement.canceled -= OnMoveCanceled;
        inputActions.Jelly.Jump.performed -= OnJumpPerformed;

        inputActions.Jelly.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 velocity = rb.linearVelocity;
        velocity.x = moveInput.x * moveSpeed;
        velocity.z = moveInput.y * moveSpeed;
        rb.linearVelocity = velocity;

    }

    private void OnMovePerformed(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext ctx)
    {
        moveInput = Vector2.zero;
    }

    private void OnJumpPerformed(InputAction.CallbackContext ctx)
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}