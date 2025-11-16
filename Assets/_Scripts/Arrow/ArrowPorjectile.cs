using UnityEngine;

public class ArrowPorjectile : MonoBehaviour
{
    public Transform target;
    public int critChange = 0;
    public int dame = 0;

    [SerializeField] private float height = 2f;
    [SerializeField] private float flyDuration = 1f;

    private Vector3 startPos;
    private float timer = 0f;

    private void OnEnable()
    {
        timer = 0f;
        startPos = transform.position;
    }
    public void ResetProjectile()
    {
        timer = 0f;
        startPos = transform.position;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        float progress = timer / flyDuration;

        if (timer > flyDuration)
        {
            PoolingObject.Instance.ReturnPool(gameObject);
            return;
        }

        Vector3 currentTargetPos = target ? target.position : startPos;

        Vector3 currentPos = Vector3.Lerp(startPos, currentTargetPos, progress);
        float heightOffset = 4 * height * progress * (1 - progress);
        currentPos.y += heightOffset;
        transform.position = currentPos;

        Vector3 direction = currentTargetPos - transform.position;
        if (direction.sqrMagnitude > 0.001f)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<DamageHandler>().DealDamage(dame, DamageVar.Physics, critChange);

            PoolingObject.Instance.ReturnPool(gameObject);
        }
    }
}
