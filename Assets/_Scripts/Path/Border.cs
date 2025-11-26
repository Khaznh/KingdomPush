using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            PoolingObject.Instance.ReturnPool(collision.gameObject);
            GameController.Instance.health -= 1;
        }
    }
}
