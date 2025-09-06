using UnityEngine;
using UnityEngine.InputSystem;

public class JellyControl : MonoBehaviour
{


    [Header("Components")]
    [SerializeField] private CharacterController characterController;

    [Header("Player Movement")]
    public float moveSpeed = 7.5f;
    public float jumpHeight = 10.0f;


    [Header("Physics")]
    public float gravity = -15.0f;

    /*
    ------------------------------------------------------
    ตัวแปรที่ใช้ภายในสคริปต์
    -------------------------------------------------------
    */

    private Vector3 playerVelocity;
    private bool isGrounded;

    private Vector2 moveInput;

    /*
    ------------------------------------------------------
    ฟังก์ชันของ Unity ที่ทำงานตอนเริ่มต้น
    -------------------------------------------------------
    */

    void Start()
    {

    }

    void Update()
    {
        HandleGrounded();
        HandleMovement();
        HandleGravity();
    }
    
    /*
    ------------------------------------------------------
    ฟังก์ชันที่ถูกเรียกโดย PlayerInput (Send Messages)
    -------------------------------------------------------
    */

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    /*
    ------------------------------------------------------
    ฟังก์ชันจัดการการทำงานส่วนต่างๆ (ใช้ค่าจาก Input System)
    -------------------------------------------------------
    */

    private void HandleGrounded()
    {
        isGrounded = characterController.isGrounded;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
    }

    private void HandleMovement()
    {
        Vector3 moveDirection = transform.right * moveInput.x + transform.forward * moveInput.y;
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void HandleGravity()
    {
        playerVelocity.y += gravity * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }
}
