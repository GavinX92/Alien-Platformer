using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAdder : MonoBehaviour {


	private PlayerCoins playerCoins;
	// Use this for initialization
	void Start () {
		playerCoins = Transform.FindObjectOfType<PlayerCoins> ();
	}

	public void AddCoin()
	{

		playerCoins.AddCoin ();
	}

}
