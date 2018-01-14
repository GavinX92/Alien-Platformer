using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

	public LevelManager levelManager;
	public Slider musicVolumeSlider;
	public Slider soundFXvolumeSlider;

	private MusicPlayer musicPlayer;


	// Use this for initialization
	void Start () {
		
		musicPlayer = FindObjectOfType<MusicPlayer> ();
		musicVolumeSlider.value = PlayerPrefsManager.GetMusicVolume ();
		soundFXvolumeSlider.value = PlayerPrefsManager.GetSoundFXvolume();
	}
	
	// Update is called once per frame
	void Update () {
		
		musicPlayer.ChangeVolume (musicVolumeSlider.value);
		MusicPlayer.SetSoundFXvolume (soundFXvolumeSlider.value);
	//	print (musicVolumeSlider);
	}

	public void SaveAndExit()
	{

		PlayerPrefsManager.SetMusicVolume (musicVolumeSlider.value);
		PlayerPrefsManager.SetSoundFXvolume (soundFXvolumeSlider.value);
		levelManager.LoadLevel (LevelManager.START_MENU_NAME);
	}


	public void SetOptionsToDefault()
	{
		musicVolumeSlider.value = 1;
		soundFXvolumeSlider.value = 1;
	}


	public void DeletePrefs()
	{
		PlayerPrefsManager.DeletePrefs ();
	}
}
