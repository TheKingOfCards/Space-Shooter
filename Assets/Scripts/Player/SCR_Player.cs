using UnityEngine;

public class SCR_Player : MonoBehaviour
{
    [HideInInspector] public SCR_MovementController MovementController;


    void Start()
    {
        MovementController = GetComponent<SCR_MovementController>();
    }


    public void UpdatePlayer()
    {
        
    }


    public void FixedUpdatePlayer()
    {
        MovementController.FixedUpdateMovement();
    }
}
