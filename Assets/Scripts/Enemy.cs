﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed =0.3f;

	private int xDir;
	private SpriteRenderer spriteRenderer;
	private Player player;
	private Animator animitor;
	private bool isAlive = true;
	// Use this for initialization
	void Start () {

		spriteRenderer = GetComponentInChildren<SpriteRenderer> ();
		player = Transform.FindObjectOfType<Player> ();
		animitor = GetComponent<Animator> ();
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
		print ("Enemy dead");
		isAlive = false;
		GameObject damagePlayerCollider = transform.Find ("Damage Player Collider").gameObject;
		damagePlayerCollider.GetComponent<BoxCollider2D> ().enabled = false;
		animitor.SetBool ("isDead", true);

	}


	public void DestroyEnemy()
	{

		Destroy (transform.parent.gameObject);
	}

}
