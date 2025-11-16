using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Enemy/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public int hp;

    public float attackRange;
    public float damage;
    public float attackRate;
    public float moveSpeed;
    public float physicalResistance;
    public float explosiveResistance;
    public float magicResistance;
    public float fireResistance;
    public float poisonResistance;
}
