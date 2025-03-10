using UnityEngine;

public class SCR_SmallAsteroid : SCR_Asteroid
{
    [SerializeField] private int spawnRotationMax;
    [HideInInspector] public bool SpawnedFormBigAsteroid = false; 


    protected override Vector3 GetMoveDirection()
    {
        if(SpawnedFormBigAsteroid)
        {
            int newRotation = Random.Range(-spawnRotationMax, spawnRotationMax);

            transform.rotation = Quaternion.Euler(new(transform.rotation.x, transform.rotation.y, transform.rotation.z + newRotation));

            return transform.up;
        }
        else return base.GetMoveDirection();
    }


    public override void Respawn(Vector3 spawnPos, Quaternion spawnRotation)
    {
        _moveVector = GetMoveDirection();

        base.Respawn(spawnPos, spawnRotation);
    }
}
