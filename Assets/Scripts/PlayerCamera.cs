using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] float cameraSensitivity = 5f;
    [SerializeField] Transform playerBody;
    [SerializeField] Camera playerCam;
    float xRot = 0;

    // Start is called before the first frame update
    void Start()
    {
        //todo make this a toggle using tab?
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        LookandRotate();
    }

    void LookandRotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        xRot = -mouseY * cameraSensitivity;
        xRot = Mathf.Clamp(xRot, -90, 90);
        
        playerCam.transform.Rotate(xRot, 0, 0);
        playerBody.Rotate(0, mouseX * cameraSensitivity, 0);

        // playerCam.transform.Rotate(xRot * cameraSensitivity, 0, 0);
        // camera vertical rotation
        // transform.localRotation = Quaternion.Euler(xRot , 0, 0);
        // player horizontal rotation
        // playerBody.Rotate(Vector3.up * mouseX);
    }

}
