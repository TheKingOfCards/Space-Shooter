using UnityEngine;

public class SCR_Player : MonoBehaviour
{
    SCR_PlayerController playerController;
    [SerializeField] public SCR_GunController gunController;

    void Start()
    {
        playerController = GetComponent<SCR_PlayerController>();
    }


    public void UpdatePlayer()
    {
        
    }


    public void FixedUpdatePlayer()
    {
        playerController.FixedUpdatePlayerController();
    }
}
