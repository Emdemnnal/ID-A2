using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour 
{
	// Creating the variables.
	Vector3 spawnPosition = new Vector3(0.009932606f, 0.448f, 8.914155f);

	// Different character prefabs for character select.
	public GameObject playerA;
	public GameObject playerB;
	public GameObject playerC;

	public InputField characterNameText;
	string savedNameText;

	// Use this for initialization
	void Start () 
	{
		savedNameText = PlayerPrefs.GetString ("savedNameText");
		characterNameText.text = savedNameText;
	}

	public void SaveName ()
	{
		savedNameText = characterNameText.text;
		PlayerPrefs.SetString ("savedNameText", savedNameText);
	}

	public void CharacterA ()
	{
		Instantiate (playerA, spawnPosition, Quaternion.identity);
	}

	public void CharacterB ()
	{
		Instantiate (playerB, spawnPosition, Quaternion.identity);
	}

	public void CharacterC ()
	{
		Instantiate (playerC, spawnPosition, Quaternion.identity);
	}
}
