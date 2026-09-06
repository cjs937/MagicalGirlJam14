using UnityEngine;
using TMPro;

public class MachineCostUI : MonoBehaviour
{
    public Transform machine;
    public TextMeshProUGUI costUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(machine.GetComponent<RouletteScript>() != null)
        {
            costUI.text = "COST " + machine.GetComponent<RouletteScript>().cost + " COINS";
        }

        if(machine.GetComponent<SlotScript>() != null)
        {
            costUI.text = "COST " + machine.GetComponent<SlotScript>().cost + " COINS";
        }

        if(machine.GetComponent<CrapsScript>() != null)
        {
            costUI.text = "COST " + machine.GetComponent<CrapsScript>().cost + " COINS";
        }
    }
}
