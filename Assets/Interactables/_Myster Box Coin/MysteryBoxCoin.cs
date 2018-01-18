using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBoxCoin : MonoBehaviour {

	private Animator animator;
	private PlayerCoins playerCoins;
	// Use this for initialization
	void Start () {
		playerCoins = Transform.FindObjectOfType<PlayerCoins> ();
		animator = GetComponent<Animator> ();
	}

	public void OnTriggerEnter2D(Collider2D collider)
	{
		
		if (collider.gameObject.GetComponent<Player> ()) {

			animator.SetTrigger ("hit trigger");
		}
	}

	public void AddCoin()
	{
		playerCoins.AddCoin ();
	}


}
