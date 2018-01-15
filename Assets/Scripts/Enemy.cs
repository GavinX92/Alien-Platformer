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
	// Use this for initialization
	void Start () {

		spriteRenderer = GetComponentInChildren<SpriteRenderer> ();
	//	player = Transform.FindObjectOfType<Player> ();
		animator = GetComponent<Animator> ();
		audioSource = GetComponent<AudioSource> ();
		audioSource.volume = MusicPlayer.GetSoundFXvolume ();
		xDir = -1;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.rotation = Quaternion.identity;
		if (isAlive) {
			Move ();
		}
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
		isAlive = false;
		animator.SetBool ("isDead", true);

	}


	public void DestroyEnemy()
	{

		Destroy (transform.parent.gameObject);
	}

}
