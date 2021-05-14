using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] float cameraSensitivity = 5f;
    [SerializeField] Transform playerBody;
    [SerializeField] Camera playerCam;
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
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        xRot = -mouseY * cameraSensitivity;
        xRot = Mathf.Clamp(xRot, -90, 90);
        
        playerCam.transform.Rotate(xRot, 0, 0);
        playerBody.Rotate(0, mouseX * cameraSensitivity, 0);
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
