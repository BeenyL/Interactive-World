using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("PlayerMovement")]
    [SerializeField] float currentSpeed;
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;

    [SerializeField] CharacterController charactercontroller;

    Vector3 inputs;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        // movement
/*        inputs.x = Input.GetAxis("Horizontal");
        inputs.z = Input.GetAxis("Vertical");*/
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        inputs = transform.TransformDirection(inputs);
        Vector3 move = transform.right * x + transform.forward * z;

        charactercontroller.Move(move * currentSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
            currentSpeed = runSpeed;
        else
            currentSpeed = walkSpeed;

    }

}
