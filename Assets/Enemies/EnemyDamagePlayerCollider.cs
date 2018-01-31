using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagePlayerCollider : MonoBehaviour {



	//TO DO: Set to detect player collision layer  

	Enemy enemy;
	private bool triggerd=false;
	// Use this for initialization
	void Start () {
		enemy = GetComponentInParent<Enemy> ();

	}

	public void OnTriggerStay2D(Collider2D collider) {

		if (triggerd) {
			return;
		}
		Player player = collider.gameObject.GetComponent<Player> ();
		if (player && !enemy.GetIsDead() && !enemy.GetIsFrozen()) {
			player.Damage ();
		}

//		if (enemy.GetIsFrozen()) {
//			player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
//		}

		triggerd = true;
		Invoke ("ResetTrigger", 1);
	}

	private void ResetTrigger()
	{
		triggerd=false;

	}
}
