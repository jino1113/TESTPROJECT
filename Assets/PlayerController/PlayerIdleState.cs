using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerIdleState : PlayerState
{
   public PlayerIdleState(FSMPlayerController player) : base(player) { }

    public override void Enter()
    {
        Debug.Log("Enter PlayerIdleState");
    }

    public override void Update()
    {
        player.ApplyGravity();

        if (player.IsMoving())
        {
            player.ChangeState(new PlayerWalkingState(player));
            return;
        }

        if(player.jumpAction.action.WasPerformedThisFrame() && player.groundedPlayer)
        {
            player.ChangeState(new PlayerJumpingState(player));
        }
    }
}
