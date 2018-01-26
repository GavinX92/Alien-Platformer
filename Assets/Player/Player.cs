﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	public float walkSpeed=2; 
	public float maxRunSpeed=4;
	public float runAnimationSpeed = 1.5f;
	public float jumpForce =5;
	public bool canWalkWhileJumping=false;
	public bool reducedWalkSpeedWhileJumping=false;
	public float jumpingWalkSpeed=1;
	public bool isRecovering;	
	public float recoverySpeed=0.75f;



	private bool playWalkAnimation=false;
	private bool jumping=false;
	private bool running =false;
	private Rigidbody2D myRigidbody;
	private GameObject body;
	private Animator animator;
	private Vector3 rotation;
	//private SpriteRenderer spriteRenderer;
	private PlayerSoundControler playerSoundControler;
	private PlayerHealth playerHealth;

	private enum EquippableItem{RaygunItem, UmbrellaItem,SwordItem};
	private EquippableItem equipedItem=EquippableItem.UmbrellaItem;
	private RayGun raygun;
	private Umbrella umbrella;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();

		body = this.transform.Find ("Body").gameObject;
		if(!body){Debug.LogError ("Can't find body");}

		animator = GetComponent<Animator> ();
		if (!animator) {Debug.LogError ("Can't find animator");}

//		 spriteRenderer =	body.GetComponent<SpriteRenderer> ();
//		if (!spriteRenderer) {Debug.LogError ("Can't find body's spriteRenderer");}

		playerSoundControler = GetComponent<PlayerSoundControler> ();
		if (!playerSoundControler) {Debug.LogError ("Can't find player sound controler");}

		playerHealth = Transform.FindObjectOfType<PlayerHealth> ();

		raygun = GetComponentInChildren<RayGun> ();
		umbrella = GetComponentInChildren<Umbrella> ();

		rotation = new Vector3 (0,0,0);
	}

	
	// Update is called once per frame
	void Update () {
		gameObject.transform.rotation =Quaternion.Euler(rotation);

		this.HandleAnimationState ();
	
		//possibly set to true by funtion call from playerControler script.
		playWalkAnimation = false;


		//TO DO: Move to SetEquipedItem
		if (equipedItem == EquippableItem.UmbrellaItem && !umbrella.striking &&
			myRigidbody.velocity.y<-0.5f) {
			myRigidbody.gravityScale = 0.1f;

		} else {
			myRigidbody.gravityScale = 1;
		}
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

		rotation = new Vector3 (0,0,0);
			playWalkAnimation = true;

		float speedToAdd = CalculateSpeedToAdd ();;

		float y = myRigidbody.velocity.y;
		myRigidbody.velocity = new Vector2(speedToAdd,y);

	}

	//called in player controler update
	public void MoveLeft()
	{
		if (jumping && !canWalkWhileJumping) {
			return;
		}
		rotation = new Vector3 (0,180,0);
			playWalkAnimation = true;

		float speedToAdd = CalculateSpeedToAdd ();;
		float y = myRigidbody.velocity.y;
		myRigidbody.velocity = new Vector2(-speedToAdd,y);

	}

	private float CalculateSpeedToAdd()
	{
		float speedToAdd;

		if (jumping && reducedWalkSpeedWhileJumping) {
			speedToAdd = jumpingWalkSpeed;

		} else if (jumping) {
			speedToAdd = walkSpeed;

		} else if(running)
		{
			speedToAdd = maxRunSpeed;
		
		}else{
			
			speedToAdd = walkSpeed;
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
	}

	public void StopRunning()
	{
		running = false;
	}

	public void Jump()
	{
		if (jumping) {
			return;
		}
		playerSoundControler.PlayJumpSound ();
		myRigidbody.velocity += Vector2.up * jumpForce;
	}


	public void UseEquipedItem(){


		if (equipedItem == EquippableItem.RaygunItem) {
			if (rotation == new Vector3 (0, 0, 0)) {
				raygun.Shoot (1);
			} else {
				raygun.Shoot (-1);

			}
		} else if (equipedItem == EquippableItem.UmbrellaItem) {

			umbrella.Strike ();
		}

	
	}

	public void Damage()
	{
		if (isRecovering) {
			return;
		}

		Debug.Log ("Player hurt");

		playerHealth.TakeDamage ();
		isRecovering = true;
		playerSoundControler.PlayHurtSound ();
		damageKockback ();
		//To Do: Slow movement while recovering.
		animator.SetBool ("isRecovering", true);
		Invoke ("EndRecovery", recoverySpeed);

	}

	public void Kill()
	{
		playerHealth.SetHealth (0);

	}

	private void damageKockback()
	{
		 float knockbackForce =-3; 
//		if (spriteRenderer.flipX) {
//			knockbackForce = -knockbackForce;
//		} 
		myRigidbody.velocity = new Vector2 (knockbackForce, 0);

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
