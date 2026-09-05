using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private RectTransform uiElement;
    [SerializeField] private Vector3 worldOffset = new Vector3(0f, 2f, 0f);

    private void Update()
    {
        Vector3 worldPosition = player.position + worldOffset;

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

        uiElement.position = screenPosition;
    }
}
