using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour
{
    public CharacterController controller;

    float speed = 10f;

    float gravity = -29.43f;
    float tempGravity;
    float wallRunningGravity = -9.82f;

    float jumpHeight = 2.5f;
    float tempJumpHeight;
    float wallRunningJumpHeight;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 crouchScale = new Vector3(1, 0.5f, 1);
    private Vector3 playerScale;

    Vector3 velocity;
    bool isGrounded;
    bool allowAcceleration;
    bool canSlide = true;
    bool canTempJump = false;

    // Update is called once per frame
    void Start()
    {
        playerScale = transform.localScale;

        wallRunningJumpHeight = jumpHeight * 2f;
    }

    void Update()
    {
        print(gravity);
        print(jumpHeight);

        //checks what ground is fro the bool 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        //stops adding velocity if we are on the ground
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded || Input.GetButtonDown("Jump") && canTempJump)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            canTempJump = false;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftControl) && isGrounded && canSlide)
        {
            StartCrouch(move);

            StartCoroutine(CrouchTimer());
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            StopCrouch();
            canSlide = true;
        }
    }
    IEnumerator CrouchTimer()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            yield return new WaitForSeconds(1f);

            StopCrouch();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            tempGravity = gravity;
            tempJumpHeight = jumpHeight;
            canTempJump = true;
            gravity = wallRunningGravity;
            jumpHeight = wallRunningJumpHeight;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wall")
        {
            gravity = tempGravity;
            jumpHeight = tempJumpHeight;
        }
    }

    private void StartCrouch(Vector3 m)
    {
        transform.localScale = crouchScale;
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        controller.Move(m * Time.deltaTime);
    }
    private void StopCrouch()
    {
        canSlide = false;
        transform.localScale = playerScale;
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
    }
}
