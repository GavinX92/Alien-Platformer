using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagePlayerCollider : MonoBehaviour {



	//TO DO: Set to detect player collision layer  

	Enemy enemy;
	// Use this for initialization
	void Start () {
		enemy = GetComponentInParent<Enemy> ();

	}

	public void OnTriggerStay2D(Collider2D collider) {

		Player player = collider.gameObject.GetComponent<Player> ();
		if (player && !enemy.GetIsDead()) {
			player.Damage ();
		}


	}
}
