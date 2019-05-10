using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggleScene : MonoBehaviour 
{
	void Update ()
	{
		if (Input.GetKeyDown ("space")) 
		{
			/*
			// Name of scene generally not changed during run-time.
			// More control and more visual when there are a lot indexed inside the build list.
			if (SceneManager.GetActiveScene ().name == "Animation")
			{
				SceneManager.LoadScene ("Scene2");
			}
			*/

			if (SceneManager.GetActiveScene ().buildIndex == 0) 
			{
				SceneManager.LoadScene (1);
			} 
			else 
			{
				SceneManager.LoadScene (0);
			}
				
		}
	}
}
