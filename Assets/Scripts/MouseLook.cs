using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    private PlayerControls controls;

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    private float xRotation, mouseX, mouseY;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Rotate.performed += ctx => Debug.Log("rotate");
    }

    // Start is called before the first frame update
    private void Start()
    {
        xRotation = 0f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
