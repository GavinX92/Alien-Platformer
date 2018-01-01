using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundControler : MonoBehaviour {

	public float soundFXvolume =1; // will be set in options menu.
	public AudioClip jumpSound;
	public float jumpSoundVolume = 0.5f;

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
		float volume = jumpSoundVolume;
		audioSource.clip = jumpSound;
		audioSource.volume =volume;
//		print (audioSource.volume);
		audioSource.Play ();

		//AudioSource.PlayClipAtPoint(jumpSound,this.transform.position,volume);
	}
}
