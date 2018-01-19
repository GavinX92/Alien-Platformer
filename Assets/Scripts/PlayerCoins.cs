using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCoins : MonoBehaviour {


	public Sprite[] digits;


	private static int coinCount=0;//static to keep value on new level/respawn.

	private SpriteRenderer tens;
	private SpriteRenderer ones;
	private AudioSource audioSource;
	private PlayerLives playerLives;

	// Use this for initialization
	void Start () {
		 tens = gameObject.transform.GetChild (2).gameObject.GetComponent<SpriteRenderer> ();
		ones = gameObject.transform.GetChild (3).gameObject.GetComponent<SpriteRenderer> ();

		audioSource = GetComponent<AudioSource> ();
		audioSource.volume = MusicPlayer.GetSoundFXvolume ();

		playerLives = Transform.FindObjectOfType<PlayerLives> ();


		UpdateCoinSprites ();
	}


	public void AddCoin()
	{

		coinCount++;
		CheckForExtraLife ();
		UpdateCoinSprites ();	
		audioSource.Play ();
	}

	private void CheckForExtraLife()
	{
		if (coinCount >= 100) {
			coinCount -= 100;
			playerLives.AddLife ();
		}

	}

	private void UpdateCoinSprites()
	{
		string coinCountString = coinCount.ToString ();
		char tensChar;
		char onesChar;

		if (coinCountString.Length == 2) {
			 tensChar = coinCountString [0];
			 onesChar = coinCountString [1];
		} else {
			tensChar = '0';
			onesChar = coinCountString [0];
		}
		int tensDigitIndex = (int)char.GetNumericValue (tensChar);
		int onesDigitIndex = (int)char.GetNumericValue (onesChar);

		tens.sprite = digits [tensDigitIndex];
		ones.sprite = digits [onesDigitIndex];


	}

	public static void SetCoinCount(int coins)
	{
		PlayerCoins.coinCount = coins;

	}
}
