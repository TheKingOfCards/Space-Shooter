using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] int amount;

    [SerializeField] SCR_PooledObject pooledObject;
    [HideInInspector] public List<SCR_PooledObject> objects = new();

    void Start()
    {
        TopUpPool();
    }


    public SCR_PooledObject GetDespawnedObject()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (!objects[i].gameObject.activeInHierarchy) return objects[i];

            if (i == objects.Count - 1)
            {
                TopUpPool();
                i = 0;
            }
        }

        return null;
    }


    public void DespawnActiveObjects()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i].gameObject.activeInHierarchy)
                objects[i].Despawn();
        }
    }


    void TopUpPool()
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject tempObj = Instantiate(pooledObject.gameObject);
            tempObj.SetActive(false);
            objects.Add(tempObj.GetComponent<SCR_PooledObject>());
        }
    }
}
