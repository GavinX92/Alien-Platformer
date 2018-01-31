using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	public enum EquippableItem{NoItem,RaygunItem, UmbrellaItem,SwordItem};

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
	private SpriteRenderer spriteRenderer;
	private GameObject body;
	private Animator animator;
	private Vector3 rotation;
	private PlayerSoundControler playerSoundControler;
	private PlayerHealth playerHealth;
	private EquippableItem equipedItem;
	private RayGun raygun;
	private Umbrella umbrella;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();

		body = this.transform.Find ("Body").gameObject;
		if(!body){Debug.LogError ("Can't find body");}

		animator = GetComponent<Animator> ();
		if (!animator) {Debug.LogError ("Can't find animator");}

		 spriteRenderer =	body.GetComponent<SpriteRenderer> ();
//		if (!spriteRenderer) {Debug.LogError ("Can't find body's spriteRenderer");}

		playerSoundControler = GetComponent<PlayerSoundControler> ();
		if (!playerSoundControler) {Debug.LogError ("Can't find player sound controler");}

		playerHealth = Transform.FindObjectOfType<PlayerHealth> ();

		raygun = GetComponentInChildren<RayGun> ();
		umbrella = GetComponentInChildren<Umbrella> ();

		rotation = new Vector3 (0,0,0);

		this.SetEqupiedItem (EquippableItem.NoItem);
	}

	
	// Update is called once per frame
	void Update () {
		gameObject.transform.rotation =Quaternion.Euler(rotation);

		this.HandleAnimationState ();
	
		//possibly set to true by funtion call from playerControler script.
		playWalkAnimation = false;



		if (equipedItem == EquippableItem.UmbrellaItem && umbrella.GetIsOpen() &&
			myRigidbody.velocity.y<-0.3) {
			myRigidbody.gravityScale = umbrella.reducedGravity;

		} else {
			myRigidbody.gravityScale =1;
		}
	}



	private void ToggleVisibility()
	{

		Color newColor;
		Color currentColor = spriteRenderer.color;
		if (currentColor.a > 0) {
			newColor = new Color ( 255,  255,  255, 0);
		} else {
			newColor = new Color ( 255,  255,  255, 255);
		}

		spriteRenderer.color = newColor;
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


		float y = myRigidbody.velocity.y;
		float x=walkSpeed;
		myRigidbody.velocity = new Vector2(x,y);

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
		myRigidbody.velocity = new Vector2 (0, 0);
		//damageKockback ();
		InvokeRepeating ("ToggleVisibility", 0, 0.1f);
		Invoke ("EndRecovery", recoverySpeed);

		this.SetEqupiedItem (EquippableItem.NoItem);
	}

	public void SetEqupiedItem(EquippableItem equipedItem)
	{

		this.equipedItem = equipedItem;

		if (equipedItem == EquippableItem.RaygunItem) {
			raygun.Activate ();
			umbrella.Deactivate ();
		

		} else if (equipedItem == EquippableItem.UmbrellaItem) {
			umbrella.Activate ();
			raygun.Deactivate ();
			
		} else if (equipedItem == EquippableItem.SwordItem) {
			

		}  


		if (equipedItem == EquippableItem.NoItem) {

			raygun.Deactivate ();
			umbrella.Deactivate ();
			animator.SetBool ("isEquiped", false);
		} else {
			animator.SetBool ("isEquiped", true);
		}
		
//		if (equipedItem == EquippableItem.RaygunItem) {
//
//
//		} else if (equipedItem == EquippableItem.UmbrellaItem) {
//
//
//		} else if(equipedItem == EquippableItem.SwordItem) {
//
//
//		}

			
	}

	public void Kill()
	{
		playerHealth.SetHealth (0);

	}

	private void damageKockback()
	{
		float knockbackForce;

		if (rotation == new Vector3 (0, 0, 0)) {
			knockbackForce=-3; 

		} else {
			knockbackForce=3; 

		}
			
		myRigidbody.velocity = new Vector2 (knockbackForce, 0);

	}

	private void EndRecovery()
	{
		isRecovering = false;
		CancelInvoke ("ToggleVisibility");
		spriteRenderer.color  = new Color ( 255,  255,  255, 255);

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
