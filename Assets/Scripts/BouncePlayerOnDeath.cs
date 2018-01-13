using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePlayerOnDeath : MonoBehaviour {

	/*
	 * 
	 * To Do: Refactor into enemy class?
	 * */

	public float bouncePlayerOnDeathPower=5;

	private bool playerBounced=false;//stops double bounce.
	private Rigidbody2D playerRigidBody;
	// Use this for initialization
	void Start () {
		Player	player = Transform.FindObjectOfType<Player> ();
		playerRigidBody = player.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BouncePlayer()
	{
		if (playerBounced) {
			return;
		}
		playerBounced = true; 
		Vector2 newVelocity = playerRigidBody.velocity;
		newVelocity.y =  bouncePlayerOnDeathPower;
		playerRigidBody.velocity =newVelocity;
		print ("player bounced " + bouncePlayerOnDeathPower);

	}
}
