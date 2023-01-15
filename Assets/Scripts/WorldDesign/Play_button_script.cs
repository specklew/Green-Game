using UnityEngine;

public class Play_button_script : MonoBehaviour
{
    public void PlayGame()
    {
        GameManager.Instance.LoadMinigame("TransportMinigame");
    }
}

