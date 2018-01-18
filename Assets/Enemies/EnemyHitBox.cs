using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour {

	//TO DO: Set to detect player collision layer  

	private Player player;
	// Use this for initialization
	void Start () {
		player = Transform.FindObjectOfType<Player> ();
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		
		FeetCollider feet = collider.gameObject.GetComponent<FeetCollider> ();

		if (feet && !player.isRecovering) {
			transform.GetComponentInParent<Enemy> ().EnemyDamaged ();

		}
	}

}
