using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour {


	public Sprite[] digits;

	private static int lives=3;//static to keep value on new level/respawn.	
	private SpriteRenderer leftDigit;
	private SpriteRenderer rightDigit;
	private AudioSource audioSource;
	private PlayerRespawner playerRespawner;


	// Use this for initialization
	void Start () {
		leftDigit = gameObject.transform.GetChild (2).gameObject.GetComponent<SpriteRenderer> ();
		rightDigit = gameObject.transform.GetChild (3).gameObject.GetComponent<SpriteRenderer> ();

		audioSource = GetComponent<AudioSource> ();
		audioSource.volume = MusicPlayer.GetSoundFXvolume ();

		playerRespawner = Transform.FindObjectOfType<PlayerRespawner> ();

		UpdateLivesDigits();
	}

	public void AddLife()
	{
		lives++;
		UpdateLivesDigits();
		audioSource.Play ();

	}

	public void LoseLife()
	{
		lives--;

		UpdateLivesDigits();
		CheckForGameOver ();
	}


	private void UpdateLivesDigits()
	{
		if (lives < 0) {
			return;
		}
		if (lives < 10) {
			rightDigit.enabled = false;
			leftDigit.sprite = digits [lives];
		} else {
			rightDigit.enabled = true;
			string livesString = lives.ToString ();
			char leftChar;
			char rightChar;


				leftChar = livesString [0];
				rightChar = livesString [1];
			
			int leftDigitIndex = (int)char.GetNumericValue (leftChar);
			int rightDigitIndex = (int)char.GetNumericValue (rightChar);

			leftDigit.sprite = digits [leftDigitIndex];
			rightDigit.sprite = digits [rightDigitIndex];

		}

	}


	private void CheckForGameOver()
	{
		if (lives < 0) {
			LevelManager.LoadLevel (LevelManager.LOSE_SCREEN_NAME);
		} else {
			playerRespawner.RespawnPlayer ();
		}


	}

	public static void SetLives(int lives)
	{

		PlayerLives.lives = lives;
	}



}
