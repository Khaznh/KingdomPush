using UnityEngine;
using UnityEngine.EventSystems;

public class MapCollider : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        MouseLogic.Instance.ChangeMouseVar(MouseVar.None, null);
    }
}
