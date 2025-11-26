using UnityEngine;
using UnityEngine.EventSystems;

public class PositionSpawn : MonoBehaviour
{
    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    Debug.Log("Clicked: " + gameObject.name);
    //    MouseLogic.Instance.ChangeMouseVar(MouseVar.SpawnerTower, this.transform);
    //}

    private void OnMouseDown()
    {
        Debug.Log("Clicked: " + gameObject.name);
        MouseLogic.Instance.ChangeMouseVar(MouseVar.SpawnerTower, this.transform);
    }
}
