using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TowerEntity : Entity
{
    public Animator pedestalAnimator;
    public Animator unitAnimator;
    public CircleCollider2D circleCollider;
    public GameObject projectilePrefaps;

    public TowerIdle towerIdle;
    public TowerAttack towerAttack;
    public TowerRecharge towerRecharge;

    public TowerStats stats;

    public List<GameObject> enemyInRange;

    public int currentLevel = 0;

    protected override void Awake()
    {
        pedestalAnimator = transform.Find("Pedestal").GetComponent<Animator>();
        unitAnimator = transform.Find("Unit").GetComponent<Animator>();
        circleCollider = GetComponent<CircleCollider2D>();

        base.Awake();
        SetUpData();

        towerIdle = new TowerIdle(fsm, this);
        towerAttack = new TowerAttack(fsm, this);
        towerRecharge = new TowerRecharge(fsm, this);

        fsm.Init(towerIdle);
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
