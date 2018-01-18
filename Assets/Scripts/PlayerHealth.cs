﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public LevelManager levelManager;
	public Sprite heartFull;
	public Sprite heartEmpty;

	private int maxHealth = 3;
	private int currentHealth=3;

	private Image[] heartImages; 
	private PlayerLives playerLives;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		
		heartImages = GetComponentsInChildren<Image> ();
		playerLives = Transform.FindObjectOfType<PlayerLives> ();

		audioSource = GetComponent<AudioSource> ();
		audioSource.volume = MusicPlayer.GetSoundFXvolume ();

	   currentHealth=2;
		UpdateHeartImages ();
	}
	


	public void SetHealth(int health)
	{
		currentHealth = health;

		UpdateHeartImages ();

		CheckForDeath ();
	}
	public void TakeDamage()
	{
		currentHealth--;

		UpdateHeartImages ();

		CheckForDeath ();

	}

	public void GainHeart()
	{
		currentHealth++;
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
		UpdateHeartImages ();

		audioSource.Play ();

	}

	private void UpdateHeartImages()
	{
		for (int i = 0; i < maxHealth; i++) {

			if (i < currentHealth) {

				heartImages [i].sprite = heartFull;
			} else {
				heartImages [i].sprite = heartEmpty;
			}

		}	
	}

	private void CheckForDeath()
	{
		if (currentHealth == 0) {
			Debug.Log ("Player Dead");
			playerLives.LoseLife ();

		}


	}




}
