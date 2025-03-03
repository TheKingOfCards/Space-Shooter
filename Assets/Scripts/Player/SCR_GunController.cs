using System.Collections;
using System.Linq;
using UnityEngine;

public class SCR_GunController : MonoBehaviour
{
    [SerializeField] private float _primaryAttackCooldown; 
    [SerializeField] private Transform _gunTransform;
    private bool _canPrimaryAttack = true;

    public void SwitchAttackState(bool aBool) => _canPrimaryAttack = aBool;
    

    private void OnPrimaryAttack()
    {
        if(!_canPrimaryAttack) return;

        SCR_PooledObject tempBullet = SCR_GameManager.Instance.ObjectPoolsManager.BulletPool.GetDespawnedObject();
        tempBullet.Respawn(_gunTransform.position, transform.rotation);

        StartCoroutine(PrimaryAttackCooldown());
    }


    private IEnumerator PrimaryAttackCooldown()
    {
        _canPrimaryAttack = false;

        yield return new WaitForSeconds(_primaryAttackCooldown);

        _canPrimaryAttack = true;
    }
}
