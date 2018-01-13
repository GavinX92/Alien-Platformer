using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundControler : MonoBehaviour {

	public float soundFXvolume =1; // will be set in options menu.

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
		float volume = jumpSoundVolume * soundFXvolume;
		audioSource.clip = jumpSound;
		audioSource.volume =volume;
		audioSource.Play ();
	}

	public void PlayHurtSound()
	{
		float volume = hurtSoundVolume * soundFXvolume;
		audioSource.clip = hurtSound;
		audioSource.volume =volume;
		audioSource.Play ();
	}
}
