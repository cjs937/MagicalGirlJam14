using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoReticule : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ammoUI;
    [SerializeField] TextMeshProUGUI reloadingUI;
    void Update()
    {
        if(StatLibrary.Instance.currentAmmunition > 0)
        {
            ammoUI.gameObject.SetActive(true);
            reloadingUI.gameObject.SetActive(false);

            ammoUI.text = StatLibrary.Instance.currentAmmunition + "/" + StatLibrary.Instance.maxAmmunition;
        }
        else
        {
            ammoUI.gameObject.SetActive(false);
            reloadingUI.gameObject.SetActive(true);
        }
        
        transform.GetComponent<Image>().fillAmount = (float) StatLibrary.Instance.currentAmmunition / StatLibrary.Instance.maxAmmunition;
    }
}
