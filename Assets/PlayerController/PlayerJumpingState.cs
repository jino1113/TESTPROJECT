using UnityEngine;

public class PlayerJumpingState : PlayerState
{
    public PlayerJumpingState(FSMPlayerController player) : base(player) { }
    public override void Enter()
    {
        player.playerVelocity.y = Mathf.Sqrt(player.jumpHeight * -2f * player.gravityValue);

        Debug.Log("Enter PlayerWalkingState");
    }

    public override void Update()
    {
        player.playerVelocity.y += player.gravityValue * Time.deltaTime;
        player.controller.Move(player.playerVelocity * Time.deltaTime);

        if(player.groundedPlayer && player.playerVelocity.y <0)
        {
            player.ChangeState(new PlayerIdleState(player));
        }
    }
}
