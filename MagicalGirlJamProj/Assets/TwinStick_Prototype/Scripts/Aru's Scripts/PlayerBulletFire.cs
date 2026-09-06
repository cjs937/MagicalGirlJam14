using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using DG.Tweening;

public class PlayerBulletFire : MonoBehaviour
{
    [SerializeField] private InputActionReference m_bulletFire;

    [Header("Projectile Prefabs")]
    [SerializeField] Transform Cur_bullet;
    [SerializeField] Transform Cur_bulletSpread;

    [Header("Projectile Settings")]
    private bool fireBullet;
    private float nextFire = 0f;
    public float projectileSpeed = 500f;

    public Transform reticule;
    public Transform spawnParticle;

    public Transform spotlight;
    public float spotlightTime = .15f;
    public Vector3 spotlightStartScale;
    [Header("Weapon Type")]
    

    [Header("Bullet Types")] 
    public Transform BasicBullet;
    public Transform KnockbackBullet;
    public Transform CritBullet;
    public Transform SlowBullet;
    public Transform ExplosiveBullet;
    
    private List<Transform> BulletTypePool = new List<Transform>();
    
    
    [Header("Bullet Spreadshot Types")] 
    public Transform Singleshot;
    public Transform Spreadshotx3;
    public Transform Spreadshotx5;
    public Transform Radialshotx8;
    
    private List<Transform> BulletSpreadPool = new List<Transform>();
    
    [Header("Audio Clips")]
    public AudioClip[] clips;
    public float clipVolume = 1f;

    void Start()
    {
        m_bulletFire.action.Enable();
        m_bulletFire.action.performed += StartBulletFire;
        m_bulletFire.action.canceled += EndBulletFire;

        StatLibrary.Instance.currentAmmunition = StatLibrary.Instance.maxAmmunition;
        
        BulletTypePool.Add(BasicBullet);
        BulletTypePool.Add(KnockbackBullet);
        BulletTypePool.Add(CritBullet);
        //BulletTypePool.Add(SlowBullet);
        BulletTypePool.Add(ExplosiveBullet);
        
        BulletSpreadPool.Add(Singleshot);
        BulletSpreadPool.Add(Spreadshotx3);
        BulletSpreadPool.Add(Spreadshotx5);
        BulletSpreadPool.Add(Radialshotx8);

        GiveMeBulletType(0);
        GiveMeBulletSpread(0);
        //KnockbackBullet =  transform.Find("Bullet Type/Knockback Bullet");
        spotlightStartScale = spotlight.localScale;
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
        if(StatLibrary.Instance.currentAmmunition > 0)
        {
            Transform[] bulletSpawns = Cur_bulletSpread.GetComponentsInChildren<Transform>();

            for(int i = 1; i < bulletSpawns.Length; i++)
            {
                if(spawnParticle != null)
                {
                    Transform activeParticle = Instantiate(spawnParticle, bulletSpawns[i].position, bulletSpawns[i].rotation);
                    activeParticle.parent = null;
                    activeParticle.gameObject.SetActive(true);
                }

                //Vector3 currentScale = Cur_bullet.localScale;
                //Cur_bullet.localScale = new Vector3(0f, 0f, 0f);

                Transform activeBullet = Instantiate(Cur_bullet, bulletSpawns[i].position, Cur_bullet.rotation);
                activeBullet.gameObject.SetActive(true);
                activeBullet.GetComponent<Rigidbody>().AddForce(bulletSpawns[i].forward * projectileSpeed);
            }

            StartCoroutine(LightFlash());

            if(reticule != null && reticule.GetComponent<ReticuleHitFlash>() != null)
            {
                reticule.GetComponent<ReticuleHitFlash>().PlayFlash();
            }

            if(clips.Length > 0 && transform.GetComponent<AudioSource>() != null)
            {
                transform.GetComponent<AudioSource>().pitch = Random.Range(0.65f, 1.1f);
                transform.GetComponent<AudioSource>().PlayOneShot(clips[Random.Range(0, clips.Length)], clipVolume);
            }
            
            StatLibrary.Instance.currentAmmunition -= 1;
        }

        if(StatLibrary.Instance.currentAmmunition <= 0)
        {
            StartCoroutine(BulletFireReload());
        }
    }

    public IEnumerator BulletFireReload()
    {
        yield return new WaitForSeconds(StatLibrary.Instance.reloadTime);
        StatLibrary.Instance.currentAmmunition = StatLibrary.Instance.maxAmmunition;
    }

    public IEnumerator LightFlash()
    {
        spotlight.DOKill();

        spotlight.gameObject.SetActive(true);
        spotlight.DOScale(spotlightStartScale, spotlightTime).SetEase(Ease.OutQuad);;

        yield return new WaitForSeconds(spotlightTime);
        spotlight.gameObject.SetActive(false);
    }

    public void GiveMeBulletType(int WeaponID)
    {
        switch (WeaponID)
        {
            case <= 0:
                Cur_bullet = BasicBullet;
                break;
            case <= 1:
                Cur_bullet = KnockbackBullet;
                break;
            case <= 2:
                Cur_bullet = CritBullet;
                break;
            case <= 3:
                Cur_bullet = ExplosiveBullet;
                break;
            case <= 4:
                Cur_bullet = ExplosiveBullet;
                break;
            case <= 5:
                WeaponID = 0;
                break;
        }
    }
    
    
    public void GiveMeBulletSpread(int ModeID)
    {
        switch (ModeID)
        {
            case <= 0:
                Cur_bulletSpread = Singleshot;
                break;
            case <= 1:
                Cur_bulletSpread = Spreadshotx3;
                break;
            case <= 2:
                Cur_bulletSpread = Spreadshotx5;
                break;
            case <= 3:
                Cur_bulletSpread = Radialshotx8;
                break;
            case <= 4:
                ModeID = 0;
                break;
        }
    }
    
    
    void Update()
    {



        //GiveMeBulletSpread(0);
        //GiveMeBulletType(0);
        if (!PauseScript.paused)
        {
            if (fireBullet)
            {
                if (Time.time > nextFire)
                {
                    BulletFire();
                    nextFire = Time.time + StatLibrary.Instance.fireRate;
                }
            }
        }
        
        
        
        
        
        
    }
    
    
    
    
    
    
}
