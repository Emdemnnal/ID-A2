using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour 
{
	public AudioClip clip;

	CollectableController cc;

	void Start()
	{
		GameObject ccgo = GameObject.Find ("CollectableController");
		cc = ccgo.GetComponent<CollectableController> ();
	}

	// When the object is hit col saves player info
	void OnTriggerEnter(Collider col)
	{
		//Play the pick.wav sound..... From the players Audio source
		col.GetComponent<AudioSource>().PlayOneShot(clip);

		// Display the name
		// Display the object
		Debug.Log (gameObject.name);
		Destroy(gameObject);
		cc.IncrementCount (gameObject);
	}


}
