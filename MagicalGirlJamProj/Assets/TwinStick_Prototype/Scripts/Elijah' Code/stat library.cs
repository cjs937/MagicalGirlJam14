using UnityEngine;
using UnityEngine.InputSystem;

//holy fuck I hope this works

public class StatLibrary : MonoBehaviour
{
    
    public static StatLibrary Instance;
    
    [Header("I'm gonna fucking hurt you")]
    public float attackPower;
    public int maxAmmunition = 15;
    public int currentAmmunition = 15;
    public float reloadTime = 3f;
    public float fireRate = .2f;
    

    [Header("LET'S GO GAMBLING")] 
    public int Gold;
    
    [Header("i'M FAST AF BOI")]
    public float walkSpeed;
    
    
    [Header("Imma hit you with my maigc wand as metioned by the goat tyler the creator")]
    public float magic;
    public int maxMagic;
    
    [Header("Currently Unused Stats")]
    public float dashTime;
    public float dashSpeed;
    

    //PlayerBulletFire Usethis;

    private void Awake()
    {
        if (Instance == null)
        { Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    
    
    
    // void Update()
    // {
    //
    //     
    //    debugstat();
    // }
    //
    //
    // void debugstat()
    // {
    //     
    //     if (Input.GetKeyUp(KeyCode.O))
    //         attackPower++;
    //     if (Input.GetKeyUp(KeyCode.P))
    //         attackPower--;
    //     
    //     
    //     
    //     if (Input.GetKeyUp(KeyCode.N))
    //         dashSpeed++;
    //     if (Input.GetKeyUp(KeyCode.M))
    //         dashSpeed--;
    //     if (Input.GetKeyUp(KeyCode.V))
    //         magic++;
    //     if (Input.GetKeyUp(KeyCode.B))
    //         magic--;
    //     if (Input.GetKeyUp(KeyCode.G))
    //         maxMagic++;
    //     if (Input.GetKeyUp(KeyCode.H))
    //         maxMagic--;
    //     
    // }
    
    
    
}
