using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWaveForLevel",menuName = "Waves/Wave For Level")]
public class WaveForLevel : ScriptableObject
{
    [Header("Level Settings")]
    public string levelName = "Level 1";
    public float startTimer = 5f;
    public float delayBetweenWaves = 5f;

    public List<Wave> waves;
    public int coinSpawnSoon;
}
