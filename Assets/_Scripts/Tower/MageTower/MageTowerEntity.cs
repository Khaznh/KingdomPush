using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MageTowerEntity : Entity
{
    public SpriteRenderer spriteRenderer;
    public CircleCollider2D circleCollider;

    public TowerStats stats;
    public GameObject mageBullet;

    public List<Sprite> levelSprite;

    public int currentLevel = 0;
    public List<GameObject> enemyInRange;

    public MageTowerIdle idle;
    public MageTowerAttack attack;
    public MageTowerRechange rechange;

    protected override void Awake()
    {
        spriteRenderer = transform.Find("Pedestal").GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();

        base.Awake();

        SetUpData();

        idle = new MageTowerIdle(fsm, this);
        attack = new MageTowerAttack(fsm, this);
        rechange = new MageTowerRechange(fsm, this);

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
