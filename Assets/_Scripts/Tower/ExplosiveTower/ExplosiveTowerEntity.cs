using System.Collections.Generic;
using UnityEngine;

public class ExplosiveTowerEntity : Entity
{
    public SpriteRenderer spriteRenderer;
    public CircleCollider2D circleCollider;

    public TowerStats stats;
    public GameObject explosiveBullet;

    public List<Sprite> levelSprite;

    public int currentLevel = 0;
    public List<GameObject> enemyInRange;

    public ExplosiveTowerIdle idle;
    public ExplosiveTowerAttack attack;
    public ExplosiveTowereRechange rechange;

    protected override void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
        base.Awake();
        SetUpData();

        idle = new ExplosiveTowerIdle(fsm, this);
        attack = new ExplosiveTowerAttack(fsm, this);
        rechange = new ExplosiveTowereRechange(fsm, this);

        fsm.Init(idle);
    }

    private void SetUpData()
    {
        circleCollider.radius = stats.levels[currentLevel].attackRange;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyInRange.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyInRange.Remove(collision.gameObject);
        }
    }
}
