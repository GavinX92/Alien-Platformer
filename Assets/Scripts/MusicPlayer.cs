using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {


	static MusicPlayer instance=null;

	private static float soundFXvolume;
	private AudioSource audioSource;


	// Use this for initialization
	void Awake()
	{
		if (instance == null) {
			instance = this;
			soundFXvolume = PlayerPrefsManager.GetSoundFXvolume ();
		} else {
			GameObject.Destroy (gameObject);
		}
	}
	void Start () {
		
		GameObject.DontDestroyOnLoad (gameObject);

		audioSource = GetComponent<AudioSource> ();
	}
	


	public void ChangeVolume(float volume)
	{
		audioSource.volume = volume;

	}

	public static void SetSoundFXvolume(float soundFXvolume)
	{
		MusicPlayer.soundFXvolume = soundFXvolume;

	}

	public static float GetSoundFXvolume()
	{

		return soundFXvolume;
	}


	public static MusicPlayer GetInstance()
	{

		return instance;
	}
}
