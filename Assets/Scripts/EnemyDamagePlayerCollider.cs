using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagePlayerCollider : MonoBehaviour {


	Enemy enemy;
	// Use this for initialization
	void Start () {
		enemy = GetComponentInParent<Enemy> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D collider) {

		Player player = collider.gameObject.GetComponent<Player> ();
		if (player && enemy.isAlive) {
			player.Damage ();
		}


	}
}
