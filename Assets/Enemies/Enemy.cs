using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed =0.3f;

	private bool isDead = false;
	private bool isFrozen=false;
	private bool isMoving =true;
	private int xDir;
	private int yDir;

	private Animator animator;
	private AudioSource audioSource;
	private Vector2 startPosition;
	private Vector3 rotation;


	private Camera myCamera;
	// Use this for initialization
	void Start () {

	
		animator = GetComponent<Animator> ();
		audioSource = GetComponent<AudioSource> ();
		audioSource.volume = MusicPlayer.GetSoundFXvolume ();
		GameObject myCameraObj = GameObject.Find ("Player Camera");
		if(myCameraObj)
		{
			myCamera = myCameraObj.GetComponent<Camera> ();
		}
		startPosition = transform.position;
		xDir = -1;
		rotation = new Vector3 (0,0,0);
		if (myCamera) {

			Vector3 viewPos = myCamera.WorldToViewportPoint(transform.position);

			if (viewPos.x < 0 || viewPos.x > 1.2 ||
				viewPos.y < 0 || viewPos.y > 1.2) {

				isMoving = false;
			}

		}

	}

	// Update is called once per frame
	void Update () {
		
		gameObject.transform.rotation =Quaternion.Euler(rotation);

		if (isMoving && !isDead && !isFrozen) {
			Move ();
		}


		if (myCamera && !isMoving) {

			Vector3 viewPos = myCamera.WorldToViewportPoint(transform.position);
		
			if (viewPos.x >= 0 && viewPos.x <= 1.2 &&
				viewPos.y >= 0 && viewPos.y <= 1.2) {

				isMoving= true;
			}
		}
	}



	public void OnCollisionEnter2D(Collision2D collision) {

		if (collision.collider.gameObject.GetComponent<Enemy> () && !isFrozen) {
			ChangeDirection ();
		}

//		print ("collision");

	}

	private void Move()
	{

		float x = gameObject.transform.position.x;
		float y = gameObject.transform.position.y;
		x += xDir * speed * Time.deltaTime;
		y += yDir * speed * Time.deltaTime;
		gameObject.transform.position = new Vector3 (x, y);	
	}

	public void ChangeDirection()
	{
		this.xDir = -xDir;

		if (xDir < 0) {
			
			rotation = new Vector3(0,0,0);


		} else {

			rotation = new Vector3(0,180,0);
		}
	//	transform.Rotate (new Vector3(0,180,0));

	}

	public void EnemyDamaged()
	{
		if (isDead) {
			return;
		}
		print ("Enemy dead");
		this.SetIsDead (true);
	}

	public void EnemyFreeze(float freezeDuration)
	{
		animator.speed = 0;
		isFrozen = true;
		CancelInvoke ("Unfreeze");
		Invoke ("Unfreeze", freezeDuration);
	}

	public void Unfreeze()
	{
		animator.speed = 1;
		isFrozen = false;

	}

	public void DestroyEnemy()
	{
		gameObject.SetActive(false);
	}

	public void SetIsDead(bool isDead)
	{
		this.isDead = isDead;
		animator.SetBool ("isDead", isDead);
	}

	public bool GetIsDead()
	{
		return isDead;
	}


	public void SetXdir(int xDir)
	{
		this.xDir = xDir;


	}

	public void SetYdir(int yDir)
	{
		this.yDir = yDir;


	}

	public void SetRotation(Vector3 newRotation)
	{
		this.rotation = newRotation;
	}
	public void RespawnEnemy()
	{
		this.SetIsDead (false);//resets snail animator;
		transform.position = startPosition;

		Unfreeze ();

		// change if enemies ever start out facing right.
		xDir = -1;
		rotation = new Vector3(0,0,0);
	}


	public static void RespawnEnemies()
	{
		Enemy[] enemies = Transform.FindObjectsOfType<Enemy> ();
		print ("Enemy count = " + enemies.Length);
		foreach (Enemy enemy in enemies) {

			enemy.RespawnEnemy ();
		}


	}



}
