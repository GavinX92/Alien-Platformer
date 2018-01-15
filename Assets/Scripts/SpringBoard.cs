using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBoard : MonoBehaviour {

	public float launchPower=5;



	private Animator animator;
	private AudioSource myAudioSource;
	private Rigidbody2D playerRigidBody;


	//private float playerDownwardMomentum;

	private static bool triggered=false; //stops double trigger from bounce. //static stops mutiple springs triggering at once.
	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponentInParent<Animator> ();

		myAudioSource = GetComponent<AudioSource> ();
		myAudioSource.volume = MusicPlayer.GetSoundFXvolume ();

		Player	player = Transform.FindObjectOfType<Player> ();
		playerRigidBody = player.GetComponent<Rigidbody2D> ();

		GameObject playerFeet = GameObject.FindObjectOfType<FeetCollider> ().gameObject;



	}
	
	// Update is called once per frame
	void Update () {
		
	}




	public void OnTriggerEnter2D(Collider2D collider)
	{


		if (!triggered) {

			triggered = true;
			animator.SetTrigger ("bounceTrigger");}
		    


		}


	public void LaunchPlayer()
	{
		



		myAudioSource.Play ();	
		playerRigidBody.velocity += Vector2.up * launchPower;// +playerDownwardMomentum;
		Invoke("ResetTrigger",0.5f);

	}

	private void ResetTrigger()
	{

		triggered = false;
	}
}
