using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public List<RocketController> pooledObjects;
    public RocketController objectToPool;
    public int amountToPool;



    void Start()
    {
        pooledObjects = new List<RocketController>();

        PoolObjects(objectToPool);
    }
    void PoolObjects(RocketController objectToPool)
    {
        RocketController tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.gameObject.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }
    public RocketController GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].gameObject.activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
