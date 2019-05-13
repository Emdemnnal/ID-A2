using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpMenuController : MonoBehaviour 
{
	// Creating the variables.
	public GameObject popUpGameObject;
	public GameObject popUpMenu;
	public GameObject popUpDescription;

	GameObject HUDctrl2;

	public void Take()
	{
		HUDctrl2 = GameObject.FindGameObjectWithTag ("HUDController");
		HUDctrl2.GetComponent<HUDController> ().SpecialItem ();
		popUpGameObject.SetActive (false);
		popUpMenu.SetActive (false);
	}

	public void Drop()
	{
		// Closes popup menu but leaves item alone.
		popUpMenu.SetActive (false);
	}

	public void Examine()
	{
		// Opens description panel.
		popUpDescription.SetActive (true);
	}

	public void Activate()
	{
		popUpMenu.SetActive (true);
		popUpDescription.SetActive (false);
	}

	public void Deactivate ()
	{
		popUpMenu.SetActive (false);
	}
}
