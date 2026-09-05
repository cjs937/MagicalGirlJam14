using UnityEngine;

public class BulletSpin : MonoBehaviour
{
    [SerializeField] private bool spinX;
    [SerializeField] private bool spinY = true;
    [SerializeField] private bool spinZ;

    [SerializeField] private float minSpeed = 50f;
    [SerializeField] private float maxSpeed = 150f;

    private Vector3 rotationSpeed;

    void Start()
    {
        rotationSpeed = new Vector3(spinX ? Random.Range(minSpeed, maxSpeed) : 0f, spinY ? Random.Range(minSpeed, maxSpeed) : 0f, spinZ ? Random.Range(minSpeed, maxSpeed) : 0f);
    }

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
