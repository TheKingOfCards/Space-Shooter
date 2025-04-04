using TMPro;
using UnityEngine;

public class SCR_Player : MonoBehaviour
{
    [HideInInspector] public SCR_MovementController MovementController;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [HideInInspector] public int score = 0;


    void Start()
    {
        MovementController = GetComponent<SCR_MovementController>();
        UpdateUI();
    }


    public void UpdatePlayer()
    {
        
    }


    public void FixedUpdatePlayer()
    {
        MovementController.FixedUpdateMovement();
    }


    public void UpdatePlayerScore(int aInt) //* Create event that asteroids can subscribe to that calls this function when they die 
    {
        score += aInt;
        UpdateUI();
    }


    private void UpdateUI() => _scoreText.text = score.ToString();
}
