using UnityEngine;

public class PlayerReticule : MonoBehaviour
{
    private void Update()
    {
        transform.position = Input.mousePosition;
    }
}
