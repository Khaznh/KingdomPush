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
    [SerializeField] public int enemyDie = 0;

    private bool isGameOver = false;

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

        if (health <= 0)
        {
            Debug.Log("Game Over");
            Lose();
        }

        if (enemyDie >= wave.enemyNum)
        {
            Win();
        }
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

    private void Win()
    {
        if (isGameOver) return;

        PanelManager.Instance.ShowWinPanel();
        isGameOver = true;
        int star = PlayerPrefs.GetInt("Star", 0);

        if (health == 10)
        {
            PlayerPrefs.SetInt("Star", star + 3);
        } else
        {
            PlayerPrefs.SetInt("Star", star + 2);
        }
    }

    private void Lose()
    {
        if (isGameOver) return;

        PanelManager.Instance.ShowDiePanel();
        isGameOver = true;
    }
}
