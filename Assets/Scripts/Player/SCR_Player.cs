using UnityEngine;

public class SCR_Player : MonoBehaviour
{
    SCR_MovementController playerController;

    void Start()
    {
        playerController = GetComponent<SCR_MovementController>();
    }


    public void UpdatePlayer()
    {
        
    }


    public void FixedUpdatePlayer()
    {
        playerController.FixedUpdatePlayerController();
    }
}
