using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerUIManager : MonoBehaviour {
	public LevelManager levelManager;

	private GameObject selectorIcon;
	private GameObject selctorIconPositions;
	private string selectedButton;

	private AudioSource audioSource;
	// Use this for initialization
	void Start () {
		selectorIcon = GameObject.Find ("Selector Icon");
		selctorIconPositions=GameObject.Find ("Selector Icon Positions");

		audioSource = GetComponent<AudioSource> ();

		selectedButton = "Play";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {

			selectorIcon.transform.position = selctorIconPositions.transform.GetChild (0).transform.position;
			audioSource.Play ();
			selectedButton = "Play";
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			selectorIcon.transform.position = selctorIconPositions.transform.GetChild (1).transform.position;
			audioSource.Play ();
			selectedButton = "Options";
		} else if (Input.GetKeyDown (KeyCode.Return)) {
			audioSource.Play ();
			if (selectedButton == "Play") {
				levelManager.LoadLevel ("02_Level_01");

			} else if (selectedButton == "Options") {
				
				levelManager.LoadLevel ("01b_Options");
			}

		}

	}
}
