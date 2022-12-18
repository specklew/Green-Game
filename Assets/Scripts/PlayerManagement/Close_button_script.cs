using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Close_button_script : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene("WorldDesign");
    }
}
