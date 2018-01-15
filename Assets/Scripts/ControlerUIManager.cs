﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlerUIManager : MonoBehaviour {
	public LevelManager levelManager;

	public Button[] buttons;

	private GameObject selectorIcon;
	private GameObject selctorIconPositions;
	private Button selectedButton;
	private AudioSource audioSource;


	private int selectedIndex;
	// Use this for initialization
	void Start () {
		selectorIcon = GameObject.Find ("Selector Icon");
		selctorIconPositions=GameObject.Find ("Selector Icon Positions");

		audioSource = GetComponent<AudioSource> ();

		selectedIndex = 0;
		selectorIcon.transform.position = selctorIconPositions.transform.GetChild (selectedIndex).transform.position;
		selectedButton = buttons [selectedIndex];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			selectedIndex--;
			if (selectedIndex < 0) {
				selectedIndex = 0;
			} else {
				UpdateSelector ();
			}
				
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			selectedIndex++;
			if (selectedIndex > buttons.Length-1) {
				selectedIndex = buttons.Length - 1;
			} else {
				UpdateSelector ();
			}
		} else if (Input.GetKeyDown (KeyCode.Return)) {
			selectedButton.onClick.Invoke ();
		}


	}


	private void UpdateSelector()
	{
		selectorIcon.transform.position = selctorIconPositions.transform.GetChild (selectedIndex).transform.position;
		selectedButton = buttons [selectedIndex];

		audioSource.volume = MusicPlayer.GetSoundFXvolume ();
		audioSource.Play ();

	}

	public void SetSelectedButton(Button mousedOverbutton)
	{
		int index = 0;
		foreach(Button button in buttons)
		{
			if (mousedOverbutton == button) {
				selectedButton = button;
				selectedIndex = index;

			}
			index++;
		}

		UpdateSelector ();
	}
		
	public Button GetSelectedButton()
	{
		return selectedButton;
	}
}
