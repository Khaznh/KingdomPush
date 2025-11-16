using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


public class TowerSpawner : Singleton<TowerSpawner>
{
    public GameObject UI;
    private GameObject currentMenu;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (!hit.collider.CompareTag("PosTowerSpawn"))
                {
                    HideMenu();
                }
            }
        }
    }

    public void ShowMenu(Transform posTransform)
    {
        if (currentMenu != null)
        {
            HideMenu();
            currentMenu = null;
        }

        Vector3 startPos = Camera.main.WorldToScreenPoint(posTransform.position);

        currentMenu = Instantiate(UI, GameObject.Find("Canvas").transform.position, Quaternion.identity);
        currentMenu.transform.SetParent(GameObject.Find("Canvas").transform, false);
        currentMenu.GetComponent<RectTransform>().position = startPos;
    }

    public void HideMenu()
    {
        if (currentMenu == null) return;

        Destroy(currentMenu);
    }
}
