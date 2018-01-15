using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		print ("Triggered");

		Player player = collider.gameObject.GetComponent<Player> ();
		if (player) {
			player.Kill ();
		}


	}
}
