using UnityEngine;

public class MouseLogic : Singleton<MouseLogic>
{
    public MouseVar currentMouseVar = MouseVar.None;
    public Transform transformTower;

    private GameObject spawnCanva;

    public void ChangeMouseVar(MouseVar mouseVar, Transform transformButton)
    {
        if (currentMouseVar == mouseVar && this.transformTower == transformButton) return;

        if (currentMouseVar == MouseVar.None && mouseVar == MouseVar.SpawnerTower)
        {
            currentMouseVar = mouseVar;
            this.transformTower = transformButton;
            TowerSpawnLogic();
        }

        if (currentMouseVar == MouseVar.SpawnerTower && mouseVar == MouseVar.SpawnerTower)
        {
            this.transformTower = transformButton;
            TowerSpawnLogic();
        }

        if (currentMouseVar == MouseVar.SpawnerTower && mouseVar == MouseVar.None)
        {
            TurnOffSpawnUI();
            spawnCanva = null;
            transformTower = null;
            currentMouseVar = MouseVar.None;
        }
    }

    private void TurnOffSpawnUI()
    {
        if (spawnCanva != null)
        {
            Destroy(spawnCanva);
        }
    }

    private void TowerSpawnLogic()
    {
        if (currentMouseVar != MouseVar.SpawnerTower || transformTower == null) return;

        var child = transformTower.childCount;

        if (child == 0)
        {
            SpawnTowerDecision();
        }
        else
        {
            LevelTower();
        }
    }

    private void SpawnTowerDecision()
    {
        if (spawnCanva != null)
        {
            Destroy(spawnCanva);
        }

        Vector3 spawnPos = Camera.main.WorldToScreenPoint(transformTower.position);

        spawnCanva = Instantiate(TowerSpawner.Instance.spawnUI, GameObject.Find("Canvas").transform);
        spawnCanva.GetComponent<RectTransform>().position = spawnPos;
    }

    private void LevelTower()
    {
        if (spawnCanva != null)
        {
            Destroy(spawnCanva);
        }

        Vector3 spawnPos = Camera.main.WorldToScreenPoint(transformTower.position);
        spawnCanva = Instantiate(TowerSpawner.Instance.upgradeUI, GameObject.Find("Canvas").transform);
        spawnCanva.GetComponent<RectTransform>().position = spawnPos;
    }
}
