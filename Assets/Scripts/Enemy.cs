using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed =0.3f;
	public bool isAlive = true;

	private int xDir;
	private SpriteRenderer spriteRenderer;
	//private Player player;
	private Animator animator;

	private AudioSource audioSource;


	private Vector2 startPosition;
	// Use this for initialization
	void Start () {

		spriteRenderer = GetComponentInChildren<SpriteRenderer> ();
	//	player = Transform.FindObjectOfType<Player> ();
		animator = GetComponent<Animator> ();
		audioSource = GetComponent<AudioSource> ();
		audioSource.volume = MusicPlayer.GetSoundFXvolume ();
		startPosition = transform.position;
		xDir = -1;



	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.rotation = Quaternion.identity;
		if (isAlive) {
			Move ();
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
		if (!isAlive) {
			return;
		}
		print ("Enemy dead");
		this.SetIsAlive (false);


	}


	public void DestroyEnemy()
	{

		//transform.parent.gameObject.SetActive (false);
		gameObject.SetActive(false);
	}
	public void SetIsAlive(bool isAlive)
	{
		this.isAlive = isAlive;


		animator.SetBool ("isDead", !isAlive);


	}
	public void RespawnEnemy()
	{
		this.SetIsAlive (true);//resets snail animator;
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
