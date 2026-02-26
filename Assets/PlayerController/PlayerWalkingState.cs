using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerWalkingState : PlayerState
{
    public PlayerWalkingState(FSMPlayerController player) : base(player) { }

    public override void Enter()
    {
        Debug.Log("Enter PlayerWalkingState");
    }

    public override void Update()
    {
        player.ApplyGravity();

        if(!player.IsMoving())
        {
            player.ChangeState(new PlayerIdleState(player));
        }

        if(player.IsJumping())
        {
            player.ChangeState(new PlayerJumpingState(player));
        }

        Vector2 input = player.moveAction.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);

        player.controller.Move(move * player.playerSpeed * Time.deltaTime);

        if(move != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRotation, player.rotationSpeed * Time.deltaTime);
        }

        if(input == Vector2.zero)
        {
            player.ChangeState(new PlayerIdleState(player));
        }
        else if(player.jumpAction.action.WasPressedThisFrame() && player.groundedPlayer)
        {
            player.ChangeState(new PlayerJumpingState(player));
        }
    }
}
