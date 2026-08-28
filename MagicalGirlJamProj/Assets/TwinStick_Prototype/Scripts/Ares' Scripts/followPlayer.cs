using Unity.VisualScripting;
using UnityEngine;

public class followPlayer : MonoBehaviour
{

    public Transform playerMarker; //takes in player gameObject

    public float movespeed = 5;
    public float stoppingDiostance = 2;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMarker = GameObject.FindWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerMarker);

        if (Vector3.Distance(transform.position, playerMarker.position) > stoppingDiostance)
            {
            transform.position += Vector3.Normalize(playerMarker.position - transform.position) * movespeed * Time.deltaTime;
            }
    }
}
