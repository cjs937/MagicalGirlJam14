using UnityEngine;
using TMPro;
public class BulletUpgrade : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI bulletType;
    public TextMeshProUGUI bulletSpread;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletType.text = "BULLET TYPE: " + player.GetComponent<PlayerBulletFire>().Cur_bullet.name;
        bulletSpread.text = "BULLET SPREAD: " + player.GetComponent<PlayerBulletFire>().Cur_bulletSpread.name;
    }
}
