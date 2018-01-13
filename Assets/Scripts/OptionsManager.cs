using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

	public LevelManager levelManager;
	public Slider volumeSlider;
	public Slider difficultySlider;

	private MusicManager musicManager;
	// Use this for initialization
	void Start () {
		musicManager = FindObjectOfType<MusicManager> ();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume ();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty ();
	}
	
	// Update is called once per frame
	void Update () {
		
		musicManager.ChangeVolume (volumeSlider.value);
	}

	public void SaveAndExit()
	{

		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
		PlayerPrefsManager.SetDifficulty (difficultySlider.value);
		levelManager.LoadLevel (LevelManager.START_MENU_NAME);
	}


	public void SetOptionsToDefault()
	{
		volumeSlider.value = 1;
		difficultySlider.value = 2;
	}
}
