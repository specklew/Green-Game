using UnityEngine;
using UnityEngine.SceneManagement;


public class AccountMenu : MonoBehaviour
{
	private string _login;
	private string _password;
	
	public void Return ()
	{
		SceneManager.LoadScene(0);
	}	
	
	public void ReadLoginInput(string s)
	{
		_login = s;
	}
	
	public void ReadPasswordInput(string s)
	{
		_password = s;
	}
	
	public void LogIn()
	{
		if(GameManager.Instance.LogPlayer(_login, _password)) SceneManager.LoadScene("WorldDesign");
		else Debug.LogWarning("Password or username is wrong.");
		//TODO: Inform the player using UI that password or username is wrong.
	}

	public void CreateAccount()
	{
		Debug.Log("Registered player with login = " + _login + " and password = " + _password);
		GameManager.Instance.RegisterPlayer(_login, _password);
		//Here code for creating account
	}	
}
