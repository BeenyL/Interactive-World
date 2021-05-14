using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] float cameraSensitivity = 5f;
    [SerializeField] Transform playerBody;
    float xRot = 0;
    bool mToggle = true;

    void Start()
    {
        
    }

    void Update()
    {
        LookandRotate();
        toggleMouse();
    }

    void LookandRotate()
    {
        if(mToggle)
        {
            float mouseX = Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
        
            xRot -= mouseY;
            xRot = Mathf.Clamp(xRot, -90, 90);
        
            transform.localRotation = Quaternion.Euler(xRot, 0, 0);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }

    void toggleMouse()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            mToggle = !mToggle;

        if (mToggle)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;
    }

}
