using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitFlash : MonoBehaviour
{
    public float flashTime = 0.1f;
    private Material orginialMaterial;
    public Material hitFlashMaterial;

    public bool is2D = false;
    public SpriteRenderer spriteRenderer;
    Color originalColor;
    public Color flashColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!is2D)
            orginialMaterial = transform.GetComponent<MeshRenderer>().material;
        else if(spriteRenderer)
        {
            originalColor = spriteRenderer.color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SetHitFlash()
    {
        //StartCoroutine(SetHitFlash()); <--- Call this from enemy collider/trigger
        if (is2D && spriteRenderer)
        {
            spriteRenderer.color = flashColor;
        }
        else
            transform.GetComponent<MeshRenderer>().material = hitFlashMaterial; //Color.white;

        yield return new WaitForSeconds(flashTime);

        if (is2D && spriteRenderer)
            spriteRenderer.color = originalColor;
        else
            transform.GetComponent<MeshRenderer>().material = orginialMaterial;
    }
}
