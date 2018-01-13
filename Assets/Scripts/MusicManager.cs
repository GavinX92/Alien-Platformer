using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {


	public AudioClip[] audioClips;


	void Awake()
	{
		GameObject.DontDestroyOnLoad (gameObject);
	}


	public void ChangeVolume(float volume)
	{
		AudioSource audioSource = GetComponent<AudioSource> ();
		audioSource.volume = volume;

	}

	private void OnEnable() {
		SceneManager.sceneLoaded += OnSceneLoaded; // subscribe
	}
	private void OnDisable() {
		SceneManager.sceneLoaded -= OnSceneLoaded; //unsubscribe
	}


	private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) {
		AudioSource audioSource = GetComponent<AudioSource> ();
		AudioClip audioClip =audioClips [scene.buildIndex];

			if (audioClip) {
			audioSource.clip = audioClip;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}
}
