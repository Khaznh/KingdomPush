using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] public List<Button> buttons;
    private Button[] waveSpawnButton;

    public override void Awake()
    {
        base.Awake();

        waveSpawnButton = GetComponentsInChildren<Button>(); 
        CheckWaveSpawn();
    }

    private void CheckWaveSpawn()
    {
        foreach (Button button in waveSpawnButton)
        {
            if (button.name.StartsWith("WaveSpawnButtonLevel"))
            {
                buttons.Add(button);
            }
        }

        foreach (Button btn in buttons)
        {
            btn.gameObject.SetActive(false);
        }
    }
}
