using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Places : MonoBehaviour 
{

	public AudioClip clip;

	// When the object is hit col saves player info
	void OnTriggerEnter(Collider col)
	{
		//Play the pick.wav sound..... From the players Audio source
		col.GetComponent<AudioSource>().PlayOneShot(clip);

		// Display the name
		// Display the object, current object lowercase gameObject
		Debug.Log (gameObject.name);
		Destroy(gameObject);
	}
}
