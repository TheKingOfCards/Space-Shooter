using UnityEngine;

public class SCR_PooledObject : MonoBehaviour
{
    public virtual void Respawn(Vector3 spawnPos, Quaternion spawnRotation)
    {
        transform.SetPositionAndRotation(spawnPos, spawnRotation);
        gameObject.SetActive(true);
    }


    public virtual void UpdatePooledObject() {  }


    public virtual void Despawn() => gameObject.SetActive(false);
}
