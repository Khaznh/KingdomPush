using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : Singleton<PanelManager>
{
    private PoolingObject poolingObject;

    private List<PanelInstance> currentPanels = new();

    private void Start()
    {
        poolingObject = PoolingObject.Instance;
    }

    public void ShowPanel(GameObject panelPrefaps)
    {
         GameObject panel = poolingObject.GetGameObjectToSpawn(panelPrefaps);

        if (panel == null)
        {
            Debug.Log("Panel not found: " + panelPrefaps.name);
        } else
        {
            currentPanels.Add(new PanelInstance(panel.GetComponent<PanelModel>().panelID, panel));
            panel.transform.SetParent(this.transform, false);
        }
    }

    public void HideLastPanel()
    {
        if (currentPanels.Count > 0)
        {
            PanelInstance lastPanel = currentPanels[currentPanels.Count - 1];
            poolingObject.ReturnPool(lastPanel.panelInstance);
            currentPanels.RemoveAt(currentPanels.Count - 1);
        }
    }
}
