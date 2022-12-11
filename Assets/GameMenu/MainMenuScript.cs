using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
	
	public void PlayGame ()
	{
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		SceneManager.LoadScene("WorldDesign");
    }
	
	public void QuitGame ()
	{
		Debug.Log ("QUIT");
		Application.Quit();
	}
}