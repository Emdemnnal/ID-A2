using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CollectableController : MonoBehaviour 
{
	public CollectablesData[] cd;

	void Awake()
	{
		DontDestroyOnLoad (gameObject);
		if (FindObjectsOfType (GetType()).Length > 1) 
		{
			Destroy (gameObject);
		}
	}

	public void IncrementCount(GameObject go)
	{
		// Within the function 'contains' in 'mame', if it has "heart"
		if (go.name.Contains ("Heart")) 
		{
			cd [0].collectableNum++;
		} 
		else if (go.name.Contains ("SoftStar")) 
		{
			cd [1].collectableNum++;
		} 
		else if(go.name.Contains("5 Side Diamond"))
		{
			cd [2].collectableNum++;	
		}

		OutputCount ();
	}

	void OutputCount()
	{
		Debug.Log ("You have collected:");
		Debug.Log ("Hearts: " + cd [0].collectableNum);
		Debug.Log ("SoftStar: " + cd [1].collectableNum);
		Debug.Log ("5 Side Diamond: " + cd [2].collectableNum);
	}

	public void SaveData()
	{
		Debug.Log (Application.persistentDataPath);
		// The ability to convert to binary.
		BinaryFormatter bf = new BinaryFormatter ();
		// Location of a text file.
		FileStream fs = File.Create(Application.persistentDataPath + "/gameData.dat");
		bf.Serialize (fs, cd);
		fs.Close ();
		Debug.Log ("Saved Data");
	}

	void Update()
	{
		if (Input.GetKeyDown ("l"))
		{
			LoadData ();
		}
		else if(Input.GetKeyDown("s"))
		{
			SaveData ();
		}
	}
		
	public void LoadData()
	{
		if (File.Exists (Application.persistentDataPath + "/gameData.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream fs = File.Open (Application.persistentDataPath + "/gameData.dat", FileMode.Open);
			cd = (CollectablesData[])bf.Deserialize (fs);
			fs.Close ();
			Debug.Log ("Data Loaded");
		} 
		else 
		{
			Debug.LogError ("File you are trying to load from is missing!");
		}

	}
}
