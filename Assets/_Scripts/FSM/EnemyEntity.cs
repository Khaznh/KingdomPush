using UnityEngine;

public class EnemyEntity : Entity
{
    public Rigidbody2D rid;
    public SpriteRenderer sprite;
    public Path enemyPath;
    public Animator animator;

    public EnemyStats stats;
    public int hp;

    protected override void Awake()
    {
        base.Awake();

        animator = GetComponent<Animator>();
        rid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        hp = stats.hp;
    }

    public virtual void ResetEnemy()
    {

    }
}
