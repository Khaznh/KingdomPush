using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameObjectPool
{
    public GameObject source;

    public List<GameObject> pool;

    public GameObjectPool(GameObject source)
    {
        this.source = source;
        pool = new List<GameObject>();
    }

    public GameObject Get()
    {
        var itemInPool = pool.FirstOrDefault(go => !go.activeInHierarchy);

        if (itemInPool == null)
        {
            itemInPool = GameObject.Instantiate(source, Vector3.zero, Quaternion.identity);
            itemInPool.SetActive(false);
            pool.Add(itemInPool);
        }

        itemInPool.SetActive(true);
        return itemInPool;
    }
}
