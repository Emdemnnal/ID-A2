using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour 
{
	public void Quit()
	{
		Debug.Log ("Quit");
		// Exits the application.
		Application.Quit ();
		// Exits play mode in the editor.
		UnityEditor.EditorApplication.isPlaying = false;
	}
		
	public void Retry()
	{
		// Loads the game again starting from the main menu.
		SceneManager.LoadScene ("Assignment");
	}
}
