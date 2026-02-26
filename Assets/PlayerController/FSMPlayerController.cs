using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.InputSystem;

public class FSMPlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float playerSpeed = 5.0f;
    public float jumpHeight = 1.5f;
    public float gravityValue = -9.81f;
    public float rotationSpeed = 10f;

    [Header("Input Actions")]
    public InputActionReference moveAction;
    public InputActionReference jumpAction;

    public CharacterController controller;
    public Vector3 playerVelocity;
    public bool groundedPlayer;

    public PlayerState playerState;
    public Vector3 moveInput;
    public bool isJumping;

    public void Awake()
    {
        ChangeState(new PlayerIdleState(this));
    }

    public void ChangeState(PlayerState newState)
    {
        if(playerState != null)
        {
            playerState.Exit();
        }

        playerState = newState;
        playerState.Enter();
    }

    public bool IsMoving()
    {
        return moveInput.magnitude > 0.1;
    }

    public bool IsJumping()
    {
        return isJumping;
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        jumpAction.action.Disable();
    }

    public void ApplyGravity()
    {
        if(groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        Vector2 input = moveAction.action.ReadValue<Vector2>();
        moveInput = new Vector3(input.x, 0, input.y);

        if(playerState != null)
        {
            playerState.Update();
        }
    }
}
