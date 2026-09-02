using UnityEngine;
using UnityEngine.UI;


public class HP_UI : MonoBehaviour
{
    public float HP, Max_HP, Width, Height;

    [SerializeField]
    private RectTransform healthBar;

    public void SetMax_HP(float maxHP)
    {
        Max_HP = maxHP;
    }

    public void SetHealth(float health)
    {
        HP = health;
        float newWidth = (HP / Max_HP) * Width;

        healthBar.sizeDelta = new Vector2(newWidth, Height);
    }
}
