using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	public float walkSpeed=2; 
	public float runAcceleration=300;
	public float maxRunSpeed=4;
	public float runAnimationSpeed = 1.5f;
	public float jumpForce =5;
	public bool canWalkWhileJumping=false;
	public bool reducedWalkSpeedWhileJumping=false;
	public float jumpingWalkSpeed=1;
	public float recoverySpeed=3;


	private float currentRunSpeed;
	private bool playWalkAnimation=false;
	private bool jumping=false;
	private bool running =false;
	private Rigidbody2D myRigidbody;
	private GameObject body;
	private Animator animator;
	private SpriteRenderer spriteRenderer;
	private PlayerSoundControler playerSoundControler;

	private bool isRecovering;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();

		body = this.transform.Find ("Body").gameObject;
		if(!body){Debug.LogError ("Can't find body");}

		animator = GetComponent<Animator> ();
		if (!animator) {Debug.LogError ("Can't find animator");}

		 spriteRenderer =	body.GetComponent<SpriteRenderer> ();
		if (!spriteRenderer) {Debug.LogError ("Can't find body's spriteRenderer");}

		playerSoundControler = GetComponent<PlayerSoundControler> ();
		if (!playerSoundControler) {Debug.LogError ("Can't find player sound controler");}
	}

	
	// Update is called once per frame
	void Update () {
		gameObject.transform.rotation = Quaternion.identity;

		this.HandleAnimationState ();
		//possibly set to true by funtion call from playerControler script.


		playWalkAnimation = false;


	}


	private void HandleAnimationState()
	{
		if (jumping) {
			animator.SetBool ("isJumping",true);
			animator.SetBool ("isWalking", false);
		}
		else if (playWalkAnimation) {
			animator.SetBool ("isWalking", true);
			animator.SetBool ("isJumping",false);
		} else {
			animator.SetBool ("isWalking", false);
			animator.SetBool ("isJumping",false);
		}

		if (running && !isRecovering) {
			animator.speed = runAnimationSpeed;

		} else {
			animator.speed = 1;
		}
	}



	//called in player controler update
	public void MoveRight()
	{
		if (jumping && !canWalkWhileJumping) {
			return;
		}



			spriteRenderer.flipX = false;
			playWalkAnimation = true;

			
		float speedToAdd = CalculateSpeedToAdd ();;

			myRigidbody.velocity += Vector2.right * speedToAdd;


	}

	//called in player controler update
	public void MoveLeft()
	{
		if (jumping && !canWalkWhileJumping) {
			return;
		}


			spriteRenderer.flipX = true;
			playWalkAnimation = true;


		float speedToAdd = CalculateSpeedToAdd ();;

		myRigidbody.velocity += Vector2.left * speedToAdd;

	}

	private float CalculateSpeedToAdd()
	{
		float speedToAdd;

		if (jumping && reducedWalkSpeedWhileJumping) {
			speedToAdd = jumpingWalkSpeed - Mathf.Abs (myRigidbody.velocity.x);

		} else if (jumping) {
			speedToAdd = walkSpeed - Mathf.Abs (myRigidbody.velocity.x);

		} else if(running)
		{

			currentRunSpeed += runAcceleration * Time.deltaTime;

			if (currentRunSpeed > maxRunSpeed) {
				currentRunSpeed = maxRunSpeed;
				//Debug.Log ("Max Run Speed reached");

			}//end of max speed check
			speedToAdd = currentRunSpeed - Mathf.Abs (myRigidbody.velocity.x);
		}else{
			
			speedToAdd = walkSpeed - Mathf.Abs (myRigidbody.velocity.x);
		}//end of else

		//speed should never be negative;
		if (speedToAdd < 0) {
			speedToAdd= 0;
		}

		return speedToAdd;
	}






	public void StartRunning()
	{
		running = true;
		this.currentRunSpeed = walkSpeed;
		//this.maxRunSpeed += maxRunSpeed;
		//this.runAcceleration += runAcceleration;

	}

	public void StopRunning()
	{
		running = false;
		//this.maxRunSpeed = maxRunSpeed/2;
		//this.runAcceleration = runAcceleration/2;
	}

	public void Jump()
	{
		if (jumping) {
			return;
		}

		//jumping = true;
		playerSoundControler.PlayJumpSound ();
		myRigidbody.velocity += Vector2.up * jumpForce;
		//Debug.Log("Delta time = " + Time.deltaTime.ToString());
		//Debug.Log ("Velocity after jump = " + myRigidbody.velocity.ToString ());

	}

	public void Damage()
	{

		Debug.Log ("Player hurt");
		isRecovering = true;
		myRigidbody.velocity = new Vector2 (0, 0);
		animator.SetBool ("isRecovering", true);
		Invoke ("EndRecovery", recoverySpeed);

	}

	private void EndRecovery()
	{
		isRecovering = false;
		animator.SetBool ("isRecovering", false);
	}

	public void setJumping(bool jumping)
	{

		this.jumping=jumping;
	}

	public bool IsJumping()
	{
		return jumping;
	}
}
