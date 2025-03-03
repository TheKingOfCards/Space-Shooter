using UnityEngine;

public class SCR_GameManager : SCR_Statemachine
{
    public static SCR_GameManager Instance = null;
    [SerializeField] public Transform playerTransform;
    [SerializeField] public SCR_ObjectPoolsManager ObjectPoolsManager;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        SwitchState<SCR_PlayingState>();
    }


    private void Update()
    {
        UpdateStateMachine();
    }

    private void FixedUpdate()
    {
        FixedUpdateStatemachine();
    }
}
