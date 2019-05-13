using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour
{
	// Creating the variables.
	public Text timeText;
	float startTime;

    public Text scoreText;
    float currentScore;

    // ---------------------------------------------------

    public Text heartCountText;
	private int heartCount;

	public Text diamondCountText;
	private int diamondCount;

	public Text starCountText;
	private int starCount;

	public Image healthBar;

	public Text stepCountText;
	private int stepCount;

    // ---------------------------------------------------

    public Text firstObjectiveText;
    public Text secondObjectiveText;
    public Text thirdObjectiveText;

    // ---------------------------------------------------

	// For HUD calculations within Update function.
    float t;
	float s;
	float step;
	bool stillCounting;
	float timeControl;

	// ---------------------------------------------------

	public bool isStillRunning;
	public bool isGameStarted;
	public bool isGameEnded;

	public bool objective1Done;
	public bool objective2Done;
	public bool objective3Done;

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
		timeControl = Time.time;

		isStillRunning = false;
		// When character is selected, game is started.
		isGameStarted = true;
		isGameEnded = false;

		// Objectives list for visiting the places.
		objective1Done = false;
		objective2Done = false;
		objective3Done = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Time decrease over time.
		if (t > 0.0f && isGameStarted == true) 
		{
			t = startTime - (Time.time - timeControl);
			string minutes = ((int)t / 60).ToString ("00");
			string seconds = (t % 60).ToString ("00");
			timeText.text = minutes + ":" + seconds;

			if (t <= 0.0f) 
			{
				// Sets condition to true for game to end.
				isGameEnded = true;
			}
		}

		// Score management.
		if (isGameStarted == true)
		{
			s = currentScore - (stepCount * 20);
			string score = s.ToString ("000000");
			scoreText.text = score;

			if (s <= 0.0f) 
			{ 
				// Prevents score going below zero.
				currentScore = 0.0f;
				scoreText.text = "000000";
			}
		}

		// Health decrease over time.
		if (isGameStarted == true)
		{
			healthBar.fillAmount -= 0.02f * Time.deltaTime;

			if (healthBar.fillAmount == 0.0f) 
			{
				// Sets condition to true for game to end.
				isGameEnded = true;
			}
		}

		// Step counter for when player is moving.
		if (isStillRunning == true) 
		{
			step = stepCount++;
			string steps = step.ToString ("00000");
			stepCountText.text = steps;
		}

		// Game End Conditions.
		if (isGameEnded == true) 
		{
			// Loads the game over menu when boolean is set to true.
			SceneManager.LoadScene ("GameOver");
		}

		if (objective1Done == true && objective2Done == true && objective3Done == true) 
		{
			// Loads the game over menu when all objectives are done.
			SceneManager.LoadScene ("GameOver");
		}
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

    public void Objective1()
    {
        firstObjectiveText.text = "! Visit the Blockade.";
		objective1Done = true;
    }

    public void Objective2()
    {
        secondObjectiveText.text = "! Visit the Broken Pass.";
		objective2Done = true;
    }

    public void Objective3()
    {
        thirdObjectiveText.text = "! Visit the Parking Lot.";
		objective3Done = true;
    }

	public void StepCounterEnabler()
	{
		isStillRunning = true;
	}

	public void StepCounterDisabler()
	{
		isStillRunning = false;
	}

	public void SpecialItem()
	{
		currentScore -= 60000.0f;
	}
}
