using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed =0.3f;

	private bool isDead = false;
	private int xDir;
	private SpriteRenderer spriteRenderer;
	private Animator animator;
	private AudioSource audioSource;
	private Vector2 startPosition;

	// Use this for initialization
	void Start () {

		spriteRenderer = GetComponentInChildren<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
		audioSource = GetComponent<AudioSource> ();
		audioSource.volume = MusicPlayer.GetSoundFXvolume ();
		startPosition = transform.position;
		xDir = -1;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.rotation = Quaternion.identity;
		if (!isDead) {
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
