using UnityEngine;
using UnityEngine.PlayerLoop;

public class SCR_AsteroidManager : MonoBehaviour
{
    [SerializeField] private float _spawnTime;
    private float _timer = 0;

    private int _spawnAmount;


    void Start()
    {
        _timer = _spawnTime;
    }


    void Update()
    {
        if(_timer <= 0)
        {
            SCR_GameManager.Instance.ObjectPoolsManager.BigAstroidPool.GetDespawnedObject().Respawn(GetSpawnPosition(), Quaternion.Euler(0, 0, 0));
            _timer = _spawnTime;
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }


    private Vector3 GetSpawnPosition() => new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
    
}
