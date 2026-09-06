using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour
{
    public StatLibrary StatsManager;
    public TextMeshProUGUI goldUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goldUI.text = "COINS: " + StatsManager.Gold;
    }
}
