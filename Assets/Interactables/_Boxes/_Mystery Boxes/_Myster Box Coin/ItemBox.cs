using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour {


	public int numberOfHits = 1;

	private Animator animator;
	private bool triggered = false;


	private BoxEnemyBouncer boxEnemyBouncer;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		boxEnemyBouncer = GetComponentInChildren<BoxEnemyBouncer> ();
	}

	public void OnTriggerEnter2D(Collider2D collider)
	{

		if (triggered) {
			return;
		}

		Player player = collider.gameObject.GetComponent<Player> ();

		if (player) {


			//check if falling or jumping for invisible blocks.
			if (player.gameObject.GetComponent<Rigidbody2D> ().velocity.y < 0) {
				return;
			}


//			Debug.Log ("Item Box Triggered"+collider.name);
			numberOfHits--;
			if (numberOfHits == 0) {
				animator.SetTrigger ("last hit trigger");
			} else {
				animator.SetTrigger ("hit trigger");

			}
			boxEnemyBouncer.KillEnemy ();
		
			Invoke ("ResetTrigger", 1);
		}

	}


	private void ResetTrigger()
	{

		triggered = false;
	}



}
