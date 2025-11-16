using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Wave
{
    public List<GameObject> enemysInWave;
    public float delayInSpawn = 0.5f;
    public int spawnPointID;
    public int pathWayID;
}
