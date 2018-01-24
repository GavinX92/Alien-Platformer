using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMysteryBox : MonoBehaviour {




	private Animator animator;
	private BoxEnemyBouncer boxEnemyBouncer;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		boxEnemyBouncer = GetComponentInChildren<BoxEnemyBouncer> ();
	}
	public void OnTriggerEnter2D(Collider2D collider)
	{

		if (collider.gameObject.GetComponent<Player> ()) {
			animator.SetTrigger ("hit trigger");
			boxEnemyBouncer.KillEnemy ();

		}
	}


	public void AddHeart()
	{
	 
		Transform.FindObjectOfType<PlayerHealth>().GainHeart();
	}


}
