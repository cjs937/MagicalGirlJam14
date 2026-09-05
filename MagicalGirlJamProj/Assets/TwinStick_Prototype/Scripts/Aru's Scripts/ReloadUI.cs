using UnityEngine;
using UnityEngine.UI;
public class ReloadUI : MonoBehaviour
{
    public Image reloadUI;

    public float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(StatLibrary.Instance.currentAmmunition <= 0)
        {
            reloadUI.gameObject.SetActive(true);

            timer += Time.deltaTime;
            reloadUI.GetComponent<Image>().fillAmount = timer / StatLibrary.Instance.reloadTime;
        }
        else
        {
            timer = 0f;
            reloadUI.gameObject.SetActive(false);
        }
    }
}
