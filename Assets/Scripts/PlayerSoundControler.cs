using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundControler : MonoBehaviour {



	public AudioClip jumpSound;
	public float jumpSoundVolume = 0.5f;

	public AudioClip hurtSound;
	public float hurtSoundVolume = 1;

	private AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		if (!audioSource) {Debug.LogError ("Cant find audio source component.");}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayJumpSound()
	{
		float volume = jumpSoundVolume * MusicPlayer.GetSoundFXvolume();
		audioSource.clip = jumpSound;
		audioSource.volume =volume;
		audioSource.Play ();
	}

	public void PlayHurtSound()
	{
		float volume = hurtSoundVolume * MusicPlayer.GetSoundFXvolume();
		audioSource.clip = hurtSound;
		audioSource.volume =volume;
		audioSource.Play ();
	}
}
