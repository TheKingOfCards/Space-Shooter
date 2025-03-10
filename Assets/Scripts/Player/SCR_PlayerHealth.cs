using UnityEngine;

public class SCR_PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _health;


    public void TakeDamage(int damage)
    {
        _health = _maxHealth;
         
        if(_health <= 0) SCR_GameManager.Instance.SwitchState<SCR_PlayingState>();
    }
}
