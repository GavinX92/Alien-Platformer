using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella : MonoBehaviour {


	public bool striking=false;

	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Strike()
	{
		striking = true;
		animator.SetTrigger ("strike trigger");
		//Invoke ("ResetStrike", 1);


	}
	public void OnTriggerEnter2D(Collider2D collider)
	{
		Enemy enemy = collider.gameObject.GetComponent<Enemy> ();

		if (enemy) {
			enemy.EnemyDamaged ();

		}
	}
	public void ResetStrike()
	{

		striking = false;
	}

}
