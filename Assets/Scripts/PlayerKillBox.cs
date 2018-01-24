using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillBox : MonoBehaviour {

	private bool triggered=false;

	void OnTriggerEnter2D(Collider2D collider) {

		if (triggered) {
			return;
		}

		triggered=true;
		Debug.Log("Triggered player kill box");

		Player player = collider.gameObject.GetComponent<Player> ();
		if (player) {
			player.Kill ();
		}

		Invoke ("ResetTrigger", 1);
	}


	private void ResetTrigger()
	{
		triggered = false;
	}
}
