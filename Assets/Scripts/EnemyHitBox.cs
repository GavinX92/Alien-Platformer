using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour {

	private Player player;
	// Use this for initialization
	void Start () {
		player = Transform.FindObjectOfType<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		//print ("triggerd by " + collider.gameObject.name);
		FeetCollider feet = collider.gameObject.GetComponent<FeetCollider> ();
		if (feet && !player.isRecovering) {

			transform.GetComponentInParent<Enemy> ().EnemyDamaged ();
		}


	}
}
