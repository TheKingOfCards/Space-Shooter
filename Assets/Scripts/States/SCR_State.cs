using UnityEngine;

public class SCR_State : MonoBehaviour
{
    [HideInInspector] public SCR_Statemachine myStateMachine = null;
    

    public virtual void EnterState(){ }

    public virtual void UpdateState(){ }
    
    public virtual void FixedUpdateState(){ }

    public virtual void ExitState(){ }
}
