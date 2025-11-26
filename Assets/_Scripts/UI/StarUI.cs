using TMPro;
using UnityEngine;

public class StarUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI starText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        starText.text = PlayerPrefs.GetInt("Star", 0).ToString();
    }
}
