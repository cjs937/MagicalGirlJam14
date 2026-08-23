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
        if(player.GetComponent<PlayerBulletFire>().currentAmmunition > 0)
        {
            ammoText.text = "AMMO " + player.GetComponent<PlayerBulletFire>().currentAmmunition + "/" + player.GetComponent<PlayerBulletFire>().maxAmmunition;
        }
        else
        {
            ammoText.text = "RELOADING";
        }
        
    }
}
