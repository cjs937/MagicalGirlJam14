using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyOverTime : MonoBehaviour
{
    public float destroyTimer = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(TimedDestroy());
    }

    public IEnumerator TimedDestroy()
    {
        yield return new WaitForSeconds(destroyTimer);
        this.gameObject.SetActive(false);
    }
}
