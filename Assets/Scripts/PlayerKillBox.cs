using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillBox : MonoBehaviour {

	private bool triggered=false;

	private Player player;
	void Start()
	{
		player = Transform.FindObjectOfType<Player> ();

	}

	void OnTriggerEnter2D(Collider2D collider) {

		if (triggered) {
			return;
		}

		triggered=true;
		Debug.Log("Triggered player kill box" +collider.gameObject.name);
		Debug.Log ("kill box killed player");
		player.Kill ();


		Invoke ("ResetTrigger", 1);
	}


	private void ResetTrigger()
	{
		triggered = false;
	}
}
