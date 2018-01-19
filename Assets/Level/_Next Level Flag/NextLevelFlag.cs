using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelFlag : MonoBehaviour {

	public float nextLevelDelay=3;

	private Animator animator;
	private AudioSource audioSource;
	private PlayerControler playerControler;
	private Player player;
	private PlayerCamera playerCamera;
	private bool triggered;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		audioSource = GetComponent<AudioSource> ();
		playerControler = Transform.FindObjectOfType<PlayerControler>();
		player = Transform.FindObjectOfType<Player> ();
		playerCamera = Transform.FindObjectOfType<PlayerCamera> ();
		triggered = false;
	}

	void Update () {
		if (triggered) {
			player.MoveRight ();
		}
	}


	public void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.GetComponent<Player> ()) {
			triggered = true;
			playerControler.SetISAcceptingInput (false);

			if (playerCamera) {
				playerCamera.SetIsFollowingPlayer (false);
			}

			animator.SetBool ("isFlapping", true);
			audioSource.Play ();

			Invoke ("NextLevel", nextLevelDelay);
		}


	}

	private void NextLevel(){

		LevelManager.LoadNextLevel ();

	}
}
