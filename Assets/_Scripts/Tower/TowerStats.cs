using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerStats", menuName = "Tower/TowerStats")]
public class TowerStats : ScriptableObject
{
    public List<TowerStatsLevel> levels = new List<TowerStatsLevel>();

    public int startCost;
}

[System.Serializable]
public class TowerStatsLevel
{
    public float attackRange;
    public int damage;
    public float attackRate;
    public int critChange;

    public int upgradeFee;
}