using UnityEngine;

public class SCR_BigAsteroid : SCR_Asteroid
{
    [Range(0, 100)]
    [SerializeField] private int _spawnSmallAsteroidPercent;
    [SerializeField] private int _maxSmallAsteroidAmount;


    public override void Respawn(Vector3 spawnPos, Quaternion spawnRotation)
    {
        _moveVector = GetMoveDirection();

        base.Respawn(spawnPos, spawnRotation);
    }

    public override void Despawn()
    {
        base.Despawn();

        if (Random.Range(1, 100) > _spawnSmallAsteroidPercent)
            SpawnSmallAsteroids();

        SCR_GameManager.Instance.playerTransform.GetComponent<SCR_Player>().UpdatePlayerScore(2);
    }


    private void SpawnSmallAsteroids()
    {
        int spawnAmount = Random.Range(1, _maxSmallAsteroidAmount + 1);

        for (int i = 0; i < spawnAmount; i++)
        {
            SCR_SmallAsteroid smallAsteroid = SCR_GameManager.Instance.ObjectPoolsManager.SmallAstroidPool.GetDespawnedObject() as SCR_SmallAsteroid;
            smallAsteroid.SpawnedFormBigAsteroid = true;
            smallAsteroid.Respawn(transform.position, transform.rotation);
        }
    }
}
