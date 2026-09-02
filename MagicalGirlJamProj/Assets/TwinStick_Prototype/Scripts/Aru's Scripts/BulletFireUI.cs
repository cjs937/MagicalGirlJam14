using UnityEngine;
using TMPro;

public class BulletFireUI : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI ammoText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(StatLibrary.Instance.currentAmmunition > 0)
        {
            ammoText.text = "AMMO " + StatLibrary.Instance.currentAmmunition + "/" + StatLibrary.Instance.maxAmmunition;
        }
        else
        {
            ammoText.text = "RELOADING";
        }
        
    }
}
