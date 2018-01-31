using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaygunPickUp : MonoBehaviour {

	public void OnTriggerEnter2D(Collider2D collider)
	{
		Player player = collider.gameObject.GetComponent<Player> ();

		if (player) {
			player.SetEqupiedItem (Player.EquippableItem.RaygunItem);

			Destroy (gameObject);

		}
	}
}
