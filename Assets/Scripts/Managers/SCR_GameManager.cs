using UnityEngine;

public class SCR_GameManager : SCR_Statemachine
{
    public static SCR_GameManager Instance = null;
    [SerializeField] public Transform playerTransform;
    [SerializeField] public SCR_ObjectPoolsManager ObjectPoolsManager;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        SwitchState<SCR_PlayingState>();
    }


    private void Update()
    {
        UpdateStateMachine();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ObjectPoolsManager.BigAstroidPool.GetDespawnedObject().Respawn(new Vector3(9, -5, 0), Quaternion.Euler(0, 0, 0));
        }
    }

    private void FixedUpdate()
    {
        FixedUpdateStatemachine();
    }
}
