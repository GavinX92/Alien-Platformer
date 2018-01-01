using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		//print ("triggerd by " + collider.gameObject.name);
		FeetCollider feet = collider.gameObject.GetComponent<FeetCollider> ();
		if (feet) {

			transform.GetComponentInParent<Enemy> ().EnemyDamaged ();
		}


	}
}
