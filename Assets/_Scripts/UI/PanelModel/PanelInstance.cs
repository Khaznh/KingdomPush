using UnityEngine;

[System.Serializable]
public class PanelInstance
{
    public string panelID;
    public GameObject panelInstance;

    public PanelInstance(string id, GameObject instance)
    {
        panelID = id;
        panelInstance = instance;
    }
}
