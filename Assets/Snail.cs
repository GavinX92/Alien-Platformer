using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour {


	private Enemy enemy;
	private Animator animator;
	// Use this for initialization
	void Start () {
		enemy = GetComponent<Enemy> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetUp()
	{
		enemy.isAlive = true;
		animator.SetBool ("isDead", false);
	}
}
