using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
	// Creating the variables.
	public Text timeText;
	float startTime;

	public Text heartCountText;
	private int heartCount;

	public Text diamondCountText;
	private int diamondCount;

	public Text starCountText;
	private int starCount;

	public Image healthBar;

	public Text scoreText;
	float currentScore;

	float t;
	float s;
	bool stillCounting;

	// Use this for initialization
	void Start () 
	{
		// Initializes the values.
		startTime = 300.0f;
		heartCount = 0;
		diamondCount = 0;
		starCount = 0;
		currentScore = 10000.0f;

		t = 300.0f; // Time value initialized the same as startTime.
		s = 10000.0f; // Score value initialized the same as startScore.
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Time decrease over time.
		if (t > 0.0f) 
		{
			t = startTime - Time.time;
			string minutes = ((int)t / 60).ToString ("00");
			string seconds = (t % 60).ToString ("00");
			timeText.text = minutes + ":" + seconds;
		}

		// Score management.
		s = currentScore;
		string score = s.ToString ("000000");
		scoreText.text = score;

		// Prevents score going below zero.
		if (s <= 0.0f) 
		{
			currentScore = 0.0f;
			scoreText.text = "000000";
		}

		// Health decrease over time.
		healthBar.fillAmount -= 0.02f * Time.deltaTime;
	}

	public void IncrementHeartCount()
	{
		heartCount++;
		heartCountText.text = heartCount.ToString ();
		healthBar.fillAmount = healthBar.fillAmount + 0.3f;
		currentScore += 30000.0f;
	}

	public void IncrementDiamondCount()
	{
		diamondCount++;
		diamondCountText.text = diamondCount.ToString ();
		healthBar.fillAmount = healthBar.fillAmount + 0.2f;
		currentScore += 20000.0f;
	}

	public void IncrementStarCount()
	{
		starCount++;
		starCountText.text = starCount.ToString ();
		healthBar.fillAmount = healthBar.fillAmount + 0.1f;
		currentScore += 10000.0f;
	}

	public void ReduceHealth()
	{
		healthBar.fillAmount -= 0.1f;
	}
}
