using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class Recyclingg_button_script : MonoBehaviour
{
    public void PlayGame()
    {
        GameManager.Instance.LoadMinigame("Recycling Minigame");
    }
}
