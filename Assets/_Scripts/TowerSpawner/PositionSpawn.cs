using UnityEngine;
using UnityEngine.EventSystems;

public class PositionSpawn : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        MouseLogic.Instance.ChangeMouseVar(MouseVar.SpawnerTower, this.transform);
    }
}
