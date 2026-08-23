using UnityEngine;

public class ScaleOverTime : MonoBehaviour
{
    [SerializeField] private Vector3 targetScale = Vector3.one;
    [SerializeField] private float scaleTime = 1f;

    private Vector3 startScale;
    private float timer = 0f;

    public bool destroyAfterScale;
    private void Start()
    {
        startScale = transform.localScale;
    }

    private void Update()
    {
        if (timer < scaleTime)
        {
            timer += Time.deltaTime;

            float progress = Mathf.Clamp01(timer / scaleTime);
            transform.localScale = Vector3.Lerp(startScale, targetScale, progress);
        }
        else
        {
            if(destroyAfterScale)
            {
                transform.gameObject.SetActive(false);
            }
        }
    }
}
