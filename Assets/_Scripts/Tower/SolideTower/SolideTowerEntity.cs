using System.Collections.Generic;
using UnityEngine;

public class SolideTowerEntity : Entity
{
    public List<GameObject> enemyInRange;
    public List<Sprite> spriteRenderers;
    public SpriteRenderer baseSpriteRenderer;

    public SolideTowerStats stats;
    public CircleCollider2D circleCollider;

    public int currentLevelIndex = 0;
    public List<GameObject> solides;

    public GameObject solidePrefaps;

    public SolideTowerIdle idle;
    public SolideTowerSpawn spawn;

    protected override void Awake()
    {
        baseSpriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
        base.Awake();
        SetUpData();

        baseSpriteRenderer.sprite = spriteRenderers[currentLevelIndex];

        idle = new SolideTowerIdle(fsm, this);
        spawn = new SolideTowerSpawn(fsm, this);

        solidePrefaps = stats.solidePrefap;
    }

    private void SetUpData()
    {
        circleCollider.radius = stats.levels[currentLevelIndex].attackRange;
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
