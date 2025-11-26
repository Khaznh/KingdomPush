using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : Singleton<PanelManager>
{
    private PoolingObject poolingObject;

    [SerializeField] private List<PanelInstance> currentPanels = new();
    [SerializeField] private GameObject diePanelPrefabs;
    [SerializeField] private GameObject winPanelPrefabs;

    private void Start()
    {
        poolingObject = PoolingObject.Instance;
    }

    public void ShowPanel(GameObject panelPrefaps)
    {
        GameObject panel = poolingObject.GetGameObjectToSpawn(panelPrefaps);


        currentPanels.Add(new PanelInstance(panel.GetComponent<PanelModel>().panelID, panel));
        panel.transform.SetParent(this.transform, false);
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

    public void ShowDiePanel()
    {
        ShowPanel(diePanelPrefabs);
    }

    public void ShowWinPanel()
    {
        ShowPanel(winPanelPrefabs);
    }
}
