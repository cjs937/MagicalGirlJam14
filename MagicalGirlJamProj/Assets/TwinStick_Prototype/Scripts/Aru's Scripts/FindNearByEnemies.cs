using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNearByEnemies : MonoBehaviour
{
    public float findRange = 25f;
    public List<GameObject> nearbyEnemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetNearbyEnemies(float findRange)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (enemyDistance <= findRange && enemy.transform.position != transform.position)
            {
                if(!nearbyEnemies.Contains(enemy))
                {
                    nearbyEnemies.Add(enemy);
                }
            }
        }
    }
}
