using UnityEngine;
using UnityEngine.EventSystems;

public class PositionSpawn : MonoBehaviour
{
    public void OnMouseDown()
    {
        TowerSpawner.Instance.ShowMenu(transform);
    }
}
