using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCollider : MonoBehaviour {


	private Player player;
	private Vector3 offsetFromPlayer;

	// Use this for initialization
	void Start () {

		player =Transform.FindObjectOfType<Player>();
		offsetFromPlayer =  player.transform.position-this.transform.position;
	}

	// Update is called once per frame
	void Update () {
		this.transform.position =  player.transform.position - offsetFromPlayer;
		gameObject.transform.rotation = Quaternion.identity;
	}


	public void OnTriggerEnter2D(Collider2D collider) {

		if (collider.gameObject.GetComponent<Player> ()) {
			return;
		}

		if (collider.gameObject.GetComponent<JumpableSurface> ()) {
			player.setJumping (false);
		}
			
	}

	void OnTriggerStay2D(Collider2D collider){

		if (collider.gameObject.GetComponent<Player> ()) {
			return;
		}

		if (collider.gameObject.GetComponent<JumpableSurface> ()) {
			player.setJumping (false);
		}
			
	}

	public void OnTriggerExit2D(Collider2D collider) {

		if (collider.gameObject.GetComponent<Player> ()) {
			return;
		}

		if (collider.gameObject.GetComponent<JumpableSurface> ()) {
			player.setJumping (true);
		}
			
	}

}
