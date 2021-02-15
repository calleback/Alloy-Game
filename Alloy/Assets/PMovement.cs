using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour
{
    public CharacterController controller;

    float speed;
    float crouchSpeed;
    float slideSpeed;

    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 crouchScale = new Vector3(1, 0.5f, 1);
    private Vector3 playerScale;

    Vector3 velocity;
    bool isGrounded;
    bool allowAcceleration;
    bool canSlide = true;

    // Update is called once per frame
    void Start()
    {
        playerScale = transform.localScale;

        speed = 10f;
    }

    void Update()
    {
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

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
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
