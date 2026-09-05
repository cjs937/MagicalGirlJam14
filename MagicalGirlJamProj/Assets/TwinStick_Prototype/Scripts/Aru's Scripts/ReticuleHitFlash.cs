using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ReticuleHitFlash : MonoBehaviour
{
    [SerializeField] private Image healthBarFill;

    [Header("Hit Effect")]
    [SerializeField] private Color flashColor = Color.white;
    [SerializeField] private float punchStrength = 0.2f;
    [SerializeField] private float punchDuration = 0.25f;

    private RectTransform rectTransform;

    private Color originalColor;
    private Vector3 originalScale;

    private void Awake()
    {
        healthBarFill = transform.GetComponent<Image>();

        rectTransform = healthBarFill.rectTransform;
        originalColor = healthBarFill.color;

        originalScale = transform.localScale;
    }

    public void PlayFlash()
    {
        transform.localScale = originalScale;
        rectTransform.DOKill();
        healthBarFill.DOKill();

        // Pop the health bar
        rectTransform.DOPunchScale(Vector3.one * punchStrength, punchDuration,8, 0.5f);

        // Flash the color
        healthBarFill.color = originalColor;
        healthBarFill.DOColor(flashColor, .01f).SetLoops(2, LoopType.Yoyo);
    }
}
