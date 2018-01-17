using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetValuesForNewGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerLives.SetLives (3);
		PlayerCoins.SetCoinCount (0);
	}
	

}
