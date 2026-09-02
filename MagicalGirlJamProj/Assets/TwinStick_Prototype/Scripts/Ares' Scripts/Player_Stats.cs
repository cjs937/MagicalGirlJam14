using System;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{
    public float HP, MaxHP;

    [SerializeField]
    private HP_UI healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.SetMax_HP(MaxHP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHealth( float healthChange)
    {
        HP += healthChange;
        HP = Mathf.Clamp(HP, 0, MaxHP);

        healthBar.SetHealth(HP);
    }
}
