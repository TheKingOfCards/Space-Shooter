using UnityEngine;

public class SCR_PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _health;


    private void Start()
    {
        _health = _maxHealth;
    }


    public void TakeDamage(int damage)
    {
        _health -= damage;
         
        if(_health <= 0) SCR_GameManager.Instance.SwitchState<SCR_DeathState>();
    }
}
