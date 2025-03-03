using System.Collections.Generic;
using UnityEngine;

public class SCR_ObjectPoolsManager : MonoBehaviour
{
    [SerializeField] private ObjectPool _bulletPool;
    [SerializeField] private ObjectPool _bigAstroidPool;
    [SerializeField] private ObjectPool _smallAstroidPool;
    private List<ObjectPool> _allObjectPools = new();

    // Getters
    public ObjectPool BulletPool { get => _bulletPool; }
    public ObjectPool BigAstroidPool { get => _bigAstroidPool; }
    public ObjectPool SmallAstroidPool { get => _smallAstroidPool; }



    private void Start()
    {
        _allObjectPools.Add(_bulletPool);
        _allObjectPools.Add(_bigAstroidPool);
        _allObjectPools.Add(_smallAstroidPool);
    }


    public void UpdateObjectPools()
    {
        foreach (ObjectPool objectPool in _allObjectPools)
        {
            foreach (SCR_PooledObject obj in objectPool.objects)
            {
                if(obj.isActiveAndEnabled) obj.UpdatePooledObject();
            }
        }
    }
}
