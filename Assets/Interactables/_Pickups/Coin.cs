using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {


	private PlayerCoins playerCoins;
	// Use this for initialization
	void Start () {
		playerCoins = Transform.FindObjectOfType<PlayerCoins> ();
	}
	
	public void OnTriggerEnter2D(Collider2D collider) {

		if (collider.gameObject.GetComponent<Player>()) {

			playerCoins.AddCoin ();

			Destroy (gameObject);

		}



	}
}
