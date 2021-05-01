using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
#pragma warning disable 649

{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 7;
    Vector2 horizontalIput;

    [SerializeField] float jumpHeight = 2.1f;
    bool jump;
    [SerializeField] float gravity = -9f; // -9.81
    Vector3 verticalVelocity = Vector3.zero;
    [SerializeField] LayerMask groundMask;
    bool isGrounded;

    public void RecieveInput (Vector2 _horizontalInput)
    {
        horizontalIput = _horizontalInput;
        //Debug.Log("move: "+horizontalIput);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundMask);
        if (isGrounded)
        {
            verticalVelocity.y = 0;
        }

        Vector3 horizontalVelocity = (transform.right * horizontalIput.x + transform.forward * horizontalIput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);

        ///JUMP
        //Jump: v = sqrt(-2 * jumpHeight * gravity);
        if (jump)
        {
            if (isGrounded)
            {
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            }
            jump = false;
        }

        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }

    public void OnJumpPressed()
    {
        jump = true;
    }
        
}
