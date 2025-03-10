using UnityEngine;

public class SCR_PlayingState : SCR_State
{
    [SerializeField] SCR_Player player;
    

    public override void EnterState()
    {
        base.EnterState();
    }


    public override void UpdateState()
    {
        base.UpdateState();

        player.UpdatePlayer();
        SCR_GameManager.Instance.ObjectPoolsManager.UpdateObjectPools();
    }


    public override void FixedUpdateState()
    {
        base.FixedUpdateState();

        player.FixedUpdatePlayer();
    }


    public override void ExitState()
    {
        base.ExitState();

        player.MovementController.StopPlayerMovement();
    }
}
