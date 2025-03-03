using UnityEngine;

public class SCR_SmallAsteroid : SCR_Asteroid
{
    [HideInInspector] public bool SpawnedFormBigAsteroid = false; 
    [HideInInspector] public Vector3 BigAsteroidDirection;


    protected override Vector3 GetMoveDirection()
    {
        if(SpawnedFormBigAsteroid)
        {
            return default;
        }
        else return base.GetMoveDirection();
    }
}
