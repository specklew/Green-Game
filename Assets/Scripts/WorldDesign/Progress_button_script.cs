using UnityEngine;
using UnityEngine.SceneManagement;

public class Progress_button_script : MonoBehaviour
{
    public void ShowProgress()
    {
        SceneManager.LoadScene("Player Management Scene", LoadSceneMode.Additive);
    }
}
