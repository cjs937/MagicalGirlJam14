using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerBulletFire : MonoBehaviour
{
    [SerializeField] private InputActionReference m_bulletFire;

    [Header("Projectile Prefabs")]
    [SerializeField] Transform bullet;
    [SerializeField] Transform bulletSpread;

    [Header("Projectile Settings")]
    private bool fireBullet;
    private float nextFire = 0f;
    public float projectileSpeed = 500f;
    public float fireRate = .2f;

    [Header("Weapon Type")]
    public int maxAmmunition = 15;
    public int currentAmmunition = 15;
    public float reloadTime = 3f;
   
    /*
    [Header("Audio Clips")]
    public AudioClip[] clips;
    public float clipVolume = 1f;
    */
    void Start()
    {
        m_bulletFire.action.Enable();
        m_bulletFire.action.performed += StartBulletFire;
        m_bulletFire.action.canceled += EndBulletFire;

        currentAmmunition = maxAmmunition;
    }

    void StartBulletFire(InputAction.CallbackContext obj)
    {
        fireBullet = true;
    }

    void EndBulletFire(InputAction.CallbackContext obj)
    {
        fireBullet = false;
    }

    public void BulletFire()
    {
        if(currentAmmunition > 0)
        {
            Transform[] bulletSpawns = bulletSpread.GetComponentsInChildren<Transform>();

            for(int i = 1; i < bulletSpawns.Length; i++)
            {
                Transform activeBullet = Instantiate(bullet, bulletSpawns[i].position, bullet.rotation);
                activeBullet.gameObject.SetActive(true);
                activeBullet.GetComponent<Rigidbody>().AddForce(bulletSpawns[i].forward * projectileSpeed);
            }

            currentAmmunition -= 1;
        }
        else
        {
            StartCoroutine(BulletFireReload());
        }
    }

    public IEnumerator BulletFireReload()
    {
        yield return new WaitForSeconds(reloadTime);
        currentAmmunition = maxAmmunition;
    }

    void Update()
    {
        if(fireBullet)
        {
            if(Time.time > nextFire)
            {
                BulletFire();
                nextFire = Time.time + fireRate;
            }
        }
    }
}
