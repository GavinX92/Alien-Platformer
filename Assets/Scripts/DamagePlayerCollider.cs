using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D collider) {

		Player player = collider.gameObject.GetComponent<Player> ();
		if (player) {
			player.Damage ();
		}


	}
}
