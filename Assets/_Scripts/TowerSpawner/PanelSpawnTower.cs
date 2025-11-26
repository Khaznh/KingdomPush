using TMPro;
using UnityEngine;

public class PanelSpawnTower : MonoBehaviour
{
    [SerializeField] private GameObject rangeTower;
    [SerializeField] private GameObject solideTower;
    [SerializeField] private GameObject mageTower;
    [SerializeField] private GameObject bombTower;

    [SerializeField] private TowerStats rangeTowerStats;
    [SerializeField] private TowerStats solideTowerStats;
    [SerializeField] private TowerStats mageTowerStats;
    [SerializeField] private TowerStats bombTowerStats;

    private TextMeshProUGUI rangeTowerCostText;
    private TextMeshProUGUI solideTowerCostText;
    private TextMeshProUGUI mageTowerCostText;
    private TextMeshProUGUI bombTowerCostText;

    private void Awake()
    {
        rangeTowerCostText = gameObject.transform.Find("ArrowCost").GetComponent<TextMeshProUGUI>();
        solideTowerCostText = gameObject.transform.Find("SolideCost").GetComponent<TextMeshProUGUI>();
        mageTowerCostText = gameObject.transform.Find("MageCost").GetComponent<TextMeshProUGUI>();
        bombTowerCostText = gameObject.transform.Find("BombCost").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        rangeTowerCostText.text = rangeTowerStats.startCost.ToString();
        //solideTowerCostText.text = solideTowerStats.startCost.ToString();
        mageTowerCostText.text = mageTowerStats.startCost.ToString();
        bombTowerCostText.text = bombTowerStats.startCost.ToString();
    }

    public void SpawnRangeTower()
    {
        if (MouseLogic.Instance.transformTower == null)
        {
            return;
        }

        Debug.Log("Spawn Range Tower");
        var pos = MouseLogic.Instance.transformTower.position;
        pos.z = 0;
        var towerGO = Instantiate(rangeTower, pos, Quaternion.identity);
        //towerGO.transform.parent = MouseLogic.Instance.transformTower;

        MouseLogic.Instance.ChangeMouseVar(MouseVar.None,null);
    }

    public void SpawnSolideTower()
    {

    }

    public void SpawnMageTower()
    {
        if (MouseLogic.Instance.transformTower == null)
        {
            return;
        }

        Debug.Log("Spawn Mage Tower");
        var pos = MouseLogic.Instance.transformTower.position;
        pos.z = 0;
        var towerGO = Instantiate(mageTower, pos, Quaternion.identity);
        //towerGO.transform.parent = MouseLogic.Instance.transformTower;

        MouseLogic.Instance.ChangeMouseVar(MouseVar.None, null);
    }

    public void SpawnBombTower()
    {
        if (MouseLogic.Instance.transformTower == null)
        {
            return;
        }

        Debug.Log("Spawn Bomb Tower");
        var pos = MouseLogic.Instance.transformTower.position;
        pos.z = 0;
        var towerGO = Instantiate(bombTower, pos, Quaternion.identity);
        //towerGO.transform.parent = MouseLogic.Instance.transformTower;

        MouseLogic.Instance.ChangeMouseVar(MouseVar.None, null);
    }
}
