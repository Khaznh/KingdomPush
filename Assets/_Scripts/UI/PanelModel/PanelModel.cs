using System;
using UnityEngine;

public class PanelModel : MonoBehaviour
{
    public string panelID;
    public GameObject panelPrefab;

    public void ClosePanel()
    {
        PanelManager.Instance.HideLastPanel();
    }
}
