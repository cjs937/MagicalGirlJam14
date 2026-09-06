using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class MachineCostUI : MonoBehaviour
{
    public List<Transform> machines;
    public TextMeshProUGUI costUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Transform machine in machines)
        {
			SlotScript slots = machine.GetComponent<SlotScript>();
			CrapsScript craps = machine.GetComponent<CrapsScript>();
			RouletteScript roulette= machine.GetComponent<RouletteScript>();

			if (roulette != null && roulette.canPull)
			{
				costUI.text = "COST " + roulette.cost + " COINS";
				return;
			}

			if (craps != null && craps.canPull)
			{
				costUI.text = "COST " + craps.cost + " COINS";
				return;
			}

			if (slots != null && slots.canPull)
			{
				costUI.text = "COST " + slots.cost + " COINS";
				return;
			}
		}
	}
}
