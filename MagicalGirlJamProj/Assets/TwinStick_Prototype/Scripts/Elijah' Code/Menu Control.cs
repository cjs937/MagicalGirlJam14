using UnityEngine;

public class MenuControl : MonoBehaviour
{
    //bool menuoff = false;
    



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F)){
            
            gameObject.SetActive(false);
            
        }

    }
}
