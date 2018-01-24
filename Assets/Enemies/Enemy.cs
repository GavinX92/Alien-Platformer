using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed =0.3f;

	private bool isDead = false;
	private bool isMoving =true;
	private int xDir;
	private SpriteRenderer spriteRenderer;
	private Animator animator;
	private AudioSource audioSource;
	private Vector2 startPosition;

	private Camera myCamera;
	// Use this for initialization
	void Start () {

		spriteRenderer = GetComponentInChildren<SpriteRenderer> ();
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

		if (myCamera) {

			Vector3 viewPos = myCamera.WorldToViewportPoint(transform.position);

			if (viewPos.x < 0 || viewPos.x > 1 ||
				viewPos.y < 0 || viewPos.y > 1) {

				isMoving = false;
			}

		}

	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.rotation = Quaternion.identity;
		if (isMoving && !isDead) {
			Move ();
		}


		if (myCamera && !isMoving) {

			Vector3 viewPos = myCamera.WorldToViewportPoint(transform.position);
		
			if (viewPos.x >= 0 && viewPos.x <= 1 &&
				viewPos.y >= 0 && viewPos.y <= 1) {

				isMoving= true;
			}
		}
	}



	public void OnCollisionEnter2D(Collision2D collision) {

		if (collision.collider.gameObject.GetComponent<Enemy> ()) {
			ChangeDirection ();
		}

//		print ("collision");

	}

	private void Move()
	{

		float x = gameObject.transform.position.x;
		float y = gameObject.transform.position.y;
		x += xDir * speed * Time.deltaTime;

		gameObject.transform.position = new Vector3 (x, y);	
	}

	public void ChangeDirection()
	{
		this.xDir = -xDir;

		if (xDir < 0) {
			spriteRenderer.flipX = false;
		} else {
			spriteRenderer.flipX = true;
		}

	}

	public void EnemyDamaged()
	{
		if (isDead) {
			return;
		}
		print ("Enemy dead");
		this.SetIsDead (true);
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

	public void RespawnEnemy()
	{
		this.SetIsDead (false);//resets snail animator;
		transform.position = startPosition;

		// change if enemies ever start out facing right.
		xDir = -1;
		spriteRenderer.flipX = false;
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
