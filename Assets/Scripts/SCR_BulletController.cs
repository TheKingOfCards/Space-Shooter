using UnityEngine;

public class SCR_BulletController : SCR_PooledObject
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    [SerializeField] private float _timeToDespawn;
    float despawnTimer;

    void Start()
    {
        despawnTimer = _timeToDespawn;
    }


    public override void UpdatePooledObject()
    {
        transform.position += transform.up * Time.deltaTime * _speed;

        DespawnLogic();
    }


    void DespawnLogic()
    {
        if(despawnTimer >= 0) despawnTimer -= Time.deltaTime;
        else Despawn();
    }

    public override void Respawn(Vector3 spawnPos, Quaternion spawnRotation)
    {
        despawnTimer = _timeToDespawn;

        base.Respawn(spawnPos, spawnRotation);
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.TryGetComponent(out SCR_Asteroid astroid))
        {
            astroid.TakeDamage(_damage);
            Despawn();
        }
    }
}
