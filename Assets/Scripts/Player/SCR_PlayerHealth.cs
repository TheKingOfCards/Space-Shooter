using UnityEngine;
using UnityEngine.UI;

public class SCR_PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _health;
    [SerializeField] private Slider _healthBar;


    private void Start()
    {
        _health = _maxHealth;
        UpdateUI();
    }


    public void TakeDamage(int damage)
    {
        _health -= damage;

        if(_health <= 0) SCR_GameManager.Instance.SwitchState<SCR_DeathState>();

        UpdateUI();
    }


    private void UpdateUI()
    {
        _healthBar.value = (float)_health / (float)_maxHealth;
    }
}
