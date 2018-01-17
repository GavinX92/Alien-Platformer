using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnPoint : MonoBehaviour {


	private PlayerRespawner playerRespawner;
	// Use this for initialization
	void Start () {
		playerRespawner = Transform.FindObjectOfType<PlayerRespawner> ();
	}
	
	public void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.GetComponent<Player> ()) {

			playerRespawner.SetPlayerRespawnPoint (this);
		}


	}
}
