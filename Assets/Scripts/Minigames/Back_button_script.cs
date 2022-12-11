using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back_button_script : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene("WorldDesign");
    }
}
