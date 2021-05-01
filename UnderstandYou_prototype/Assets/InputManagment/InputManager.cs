using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] Player_Movement movement;
    [SerializeField] Player_MouseLook mouseLook;

    UnderstandYou_prototype controls;
    UnderstandYou_prototype.MouvementCameraActions mouvementCamera;

    Vector2 horizontalInput;
    Vector2 mouseInput;

    // Start is called before the first frame update
    private void Awake()
    {
        controls = new UnderstandYou_prototype();
        mouvementCamera = controls.MouvementCamera;

        // mouvementCamera.[action].performed += context => do something
        mouvementCamera.Move.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        mouvementCamera.Jump.performed += _ => movement.OnJumpPressed();
        mouvementCamera.Look.performed += ctx => mouseInput = ctx.ReadValue<Vector2>();
    }

    private void Update()
    {
        movement.RecieveInput(horizontalInput);
        mouseLook.RecieveInput(mouseInput);
    }

    // Update is called once per frame
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}
