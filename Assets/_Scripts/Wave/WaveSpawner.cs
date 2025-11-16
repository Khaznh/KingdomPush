using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private WaveForLevel waveForLevel;
    [SerializeField] private List<Vector3> spawnVector3;
    [SerializeField] private List<Path> paths;

    private Transform[] spawnPoints;
    private float timer = 0f;
    private bool canSpawn = true;
    private int currentIndex = 0;

    private void Awake()
    {
        if (waveForLevel == null)
        {
            Debug.LogError("Wave information is missing");
        }

        GetSpawnPoint();

        currentIndex = GameController.Instance.waveCurrent;
    }

    private void Start()
    {
        ShowSpawnButton();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (currentIndex != 0 && currentIndex < waveForLevel.waves.Count && timer >= waveForLevel.delayBetweenWaves)
        {
            SpawnEnemyByTime();
        }
    }

    private void SpawnEnemyByTime()
    {
        if (!canSpawn) return;
        canSpawn = false;
        StartCoroutine(SpawnCurrentWay());
    }

    public void SpawnEnemyByButton()
    {
        if (!canSpawn) return;
        canSpawn = false;

        GameController.Instance.gold += waveForLevel.coinSpawnSoon;

        StartCoroutine(SpawnCurrentWay());
    }

    private IEnumerator SpawnCurrentWay()
    {
        if (currentIndex >= waveForLevel.waves.Count)
        {
            yield break;
        }

        TurnOffSpawnButton();
        for (int i = 0; i < waveForLevel.waves[currentIndex].enemysInWave.Count; i++)
        {
            GameObject enemy = PoolingObject.Instance.GetGameObjectToSpawn(waveForLevel.waves[currentIndex].enemysInWave[i]);
            enemy.GetComponent<EnemyEntity>().ResetEnemy();
            enemy.transform.position = spawnVector3[currentIndex];
            enemy.GetComponent<EnemyEntity>().enemyPath = paths[currentIndex];

            yield return new WaitForSeconds(waveForLevel.waves[currentIndex].delayInSpawn);
        }

        timer = 0;
        canSpawn = true;
        GameController.Instance.GainWave();
        currentIndex++;
        ShowSpawnButton();
    }

    private void GetSpawnPoint()
    {
        GameObject eneWay = GameObject.Find("EnemyPath");

        if (eneWay == null)
        {
            Debug.LogError("Ene Way is missing");
            return;
        }

        Path[] eneWays = eneWay.GetComponentsInChildren<Path>();
        spawnPoints = transform.GetComponentsInChildren<Transform>().Skip(2).ToArray();

        for (int i = 0; i < waveForLevel.waves.Count; i++)
        {
            spawnVector3.Add(spawnPoints[waveForLevel.waves[i].spawnPointID].position);
        }

        for (int i = 0; i < waveForLevel.waves.Count; i++)
        {
            paths.Add(eneWays[waveForLevel.waves[i].pathWayID]);
        }
    }

    private void ShowSpawnButton()
    {
        if (currentIndex >= waveForLevel.waves.Count)
        {
            return;
        }

        UIManager.Instance.buttons[currentIndex].gameObject.SetActive(true);
    }

    private void TurnOffSpawnButton()
    {
        UIManager.Instance.buttons[currentIndex].gameObject.SetActive(false);
    }
}
