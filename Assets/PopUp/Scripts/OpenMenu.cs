using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    public GameObject buttom;
    public GameObject list_buttom;
    public GameObject add_buttom;
    public GameObject inv_buttom;
    public GameObject Quit_buttom;

   public void OpenPanel()
   {
        if (panel != null)
        {
            panel.SetActive(true);
            list_buttom.SetActive(true);
            add_buttom.SetActive(true);
            inv_buttom.SetActive(true);
            Quit_buttom.SetActive(true);
            buttom.SetActive(false);
        }

   }
}
