using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFlash : MonoBehaviour
{
    public float flashTime = 0.1f;
    private Material orginialMaterial;
    public Material hitFlashMaterial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        orginialMaterial = transform.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SetHitFlash()
    {
        //StartCoroutine(SetHitFlash()); <--- Call this from enemy collider/trigger
        transform.GetComponent<MeshRenderer>().material = hitFlashMaterial; //Color.white;
        yield return new WaitForSeconds(flashTime);
        transform.GetComponent<MeshRenderer>().material = orginialMaterial;
    }
}
