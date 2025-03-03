using System.Collections.Generic;
using UnityEngine;

public class SCR_Statemachine : MonoBehaviour
{
    [HideInInspector] public SCR_State currentState;
    [SerializeField] private List<SCR_State> myStates = new();


    protected void StartStateMachine()
    {
        foreach (SCR_State state in myStates)
        {
            state.myStateMachine = this;
        }
    }


    protected void UpdateStateMachine()
    {
        currentState?.UpdateState();
    }


    protected void FixedUpdateStatemachine()
    {
        currentState?.FixedUpdateState();
    }


    public void SwitchState<T>() where T : SCR_State
    {
        foreach (SCR_State state in myStates)
        {
            if(state is T)
            {
                currentState?.ExitState();
                currentState = state;
                currentState?.EnterState();
                return;
            }
        }
    }
}
