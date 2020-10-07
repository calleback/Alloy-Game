using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivty = 100f;

    public Transform playerBody;

    public bool isFrozen = false;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivty * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivty * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        if (Input.GetKeyDown(KeyCode.Escape) && !isFrozen)
        {
            Time.timeScale = 0;
            mouseSensitivty = 0;
            isFrozen = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isFrozen)
        {
            Time.timeScale = 1;
            mouseSensitivty = 100f;
            isFrozen = false;
        }
    }
}
