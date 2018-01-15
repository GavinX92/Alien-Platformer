using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsSliderSelector : MonoBehaviour {

	private Button musicVolumeButton;
	private Button soundFXvolumeButton;

	private Slider musicVolumeSlider;
	private Slider soundFXvolumeSlider;
	private Slider emptySlider;

	private ControlerUIManager controlerUIManager;
	//private Button selectedButton;
	// Use this for initialization
	void Start () {

		musicVolumeButton = GameObject.Find ("Music Volume Label").GetComponent<Button> ();
		soundFXvolumeButton = GameObject.Find ("SoundFX Volume Label").GetComponent<Button> ();

		musicVolumeSlider = GameObject.Find ("Music Volume Slider").GetComponent<Slider>();
		soundFXvolumeSlider = GameObject.Find ("Sound FX Volume Slider").GetComponent<Slider>();
		emptySlider = GameObject.Find ("Empty Slider").GetComponent<Slider>();


		controlerUIManager = GetComponent<ControlerUIManager> ();


	}
	
	// Update is called once per frame
	void Update () {
		Button	selectedButton = controlerUIManager.GetSelectedButton ();

		if (selectedButton == musicVolumeButton) {
			musicVolumeSlider.Select ();
		} else if (selectedButton == soundFXvolumeButton) {
			soundFXvolumeSlider.Select ();
		} else {
			emptySlider.Select ();

		}

	
	}
}
