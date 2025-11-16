using TMPro;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    public int gold = 50;
    public int health = 10;
    public int waveCurrent = 0;
    public int waveMax = 0;

    [SerializeField] private WaveForLevel wave;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI waveText;
    //[SerializeField] private 

    private void Start()
    {
        if (wave == null) { return;  }

        if (goldText == null || healthText == null || waveText == null)
        {
            Debug.Log("Missing UI ref");
        }

        waveMax = wave.waves.Count;
    }

    private void Update()
    {
        DisplayInfomation();
    }

    private void DisplayInfomation()
    {
        goldText.text = gold.ToString();
        healthText.text = health.ToString();
        waveText.text = $"Wave {waveCurrent + 1}/{waveMax}";
    }

    public void EarnGold(int amount)
    {
        gold += amount;
    }

    public void MinusGold(int amount)
    {
        gold -= amount;

        if (gold < 0) gold = 0;
    }

    public void MinusHealth(int amount)
    {
        health -= amount;
    }

    public void GainHealth(int amount)
    {
        health += amount;
    }

    public void GainWave()
    {
        waveCurrent++;
    }
}
