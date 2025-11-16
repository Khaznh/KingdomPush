using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolingObject : Singleton<PoolingObject>
{
    public List<GameObjectPool> pools = new();

    public GameObject GetGameObjectToSpawn(GameObject go)
    {
        var find = pools.Find(t => t.source == go);

        if (find == null)
        {
            find = new GameObjectPool(go);
            pools.Add(find);

        }

        return find.Get();
    }

    public void ReturnPool(GameObject go)
    {
        if (go == null)
        {
            return;
        }

        go.SetActive(false);
    }
}
