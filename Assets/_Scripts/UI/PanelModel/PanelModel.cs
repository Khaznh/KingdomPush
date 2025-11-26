using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelModel : MonoBehaviour
{
    public string panelID;
    public GameObject panelPrefab;

    public void ClosePanel()
    {
        PanelManager.Instance.HideLastPanel();
    }

    public void MoveToMenuSceen()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void MoveToMap(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ResetMap()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
