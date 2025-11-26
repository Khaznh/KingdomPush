using UnityEngine;
using UnityEngine.EventSystems;

public class MapCollider : MonoBehaviour
{
    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    MouseLogic.Instance.ChangeMouseVar(MouseVar.None, null);
    //}

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        MouseLogic.Instance.ChangeMouseVar(MouseVar.None, null);
    }
}
