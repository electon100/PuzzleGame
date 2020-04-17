using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private float mouseSensitivity = 100f;

    private float mouseX = 0f;
    private float mouseY = 0f;

    private float xRotation = 0f;

    public Transform playerBody;

    void Start()
    {
        // Lock the cursor so it doesn't get in the way
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Update mouse input
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Calculate new x rotation and clamp it
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Make changes to the camera and player
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
