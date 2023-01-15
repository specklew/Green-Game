using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shopping_button_script : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("ShoppingMinigame");
    }
}
