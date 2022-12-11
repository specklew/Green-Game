using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
	
    public void PlayGame ()
    {
        SceneManager.LoadScene("AccountMenuScene");
    }
	
    public void QuitGame ()
    {
        Debug.Log ("QUIT");
        Application.Quit();
    }
}