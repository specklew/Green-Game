using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AccountMenu : MonoBehaviour
{
	private string Login;
	private string Password;
	
	public void Return ()
	{
		SceneManager.LoadScene(0);
	}	
	
	public void ReadLoginInput(string s)
	{
		Login = s;
	}
	
	public void ReadPasswordInput(string s)
	{
		Password = s;
	}
	
	public void LogIn ()
	{
		Debug.Log ("Login");
		Debug.Log (Login);
		Debug.Log ("Password");
		Debug.Log (Password);
		SceneManager.LoadScene(2);
	}

	public void CreateAccount ()
	{
		Debug.Log ("Login");
		Debug.Log (Login);
		Debug.Log ("Password");
		Debug.Log (Password);
		//Here code for creating account
	}	
}
