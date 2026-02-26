using UnityEngine;

public abstract class PlayerState
{
    protected FSMPlayerController player;

    public PlayerState(FSMPlayerController player)
    {
        this.player = player;
    }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}
