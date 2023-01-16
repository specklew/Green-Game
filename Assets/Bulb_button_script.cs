using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bulb_button_script : MonoBehaviour
{
    
    public void PlayGame()
    {
        GameManager.Instance.LoadMinigame("SwitchLightMinigame");
    }
}
