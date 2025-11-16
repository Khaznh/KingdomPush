using UnityEngine;

[CreateAssetMenu(fileName = "TowerStats", menuName = "Tower/TowerStats")]
public class TowerStats : ScriptableObject
{
    public float attackRange;
    public int damage;
    public float attackRate;
    public int critChange;
}
