using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour {


	public int numberOfHits = 1;

	private Animator animator;
	private PlayerCoins playerCoins;


	private BoxEnemyBouncer boxEnemyBouncer;
	// Use this for initialization
	void Start () {
		playerCoins = Transform.FindObjectOfType<PlayerCoins> ();
		animator = GetComponent<Animator> ();

		boxEnemyBouncer = GetComponentInChildren<BoxEnemyBouncer> ();
	}

	public void OnTriggerEnter2D(Collider2D collider)
	{

		Player player = collider.gameObject.GetComponent<Player> ();
		if (player) {
			


			numberOfHits--;
			if (numberOfHits == 0) {
				animator.SetTrigger ("last hit trigger");
			} else {
				animator.SetTrigger ("hit trigger");

			}
			boxEnemyBouncer.KillEnemy ();
		
		}
	}






}
