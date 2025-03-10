using UnityEngine;

public class SCR_DeathState : SCR_State
{
    [SerializeField] private GameObject _deathUI;


    public override void EnterState()
    {
        base.EnterState();
        _deathUI.SetActive(true);

        foreach (ObjectPool objectPool in SCR_GameManager.Instance.ObjectPoolsManager.AllObjectPools)
        {
            objectPool.DespawnActiveObjects();
        }
    }


    public override void UpdateState()
    {
        base.UpdateState();
    }


    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
    }


    public override void ExitState()
    {
        base.ExitState();
        _deathUI.SetActive(false);
    }
}
