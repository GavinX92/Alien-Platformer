using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {

	private PlayerHealth playerHealth;
	// Use this for initialization
	void Start () {
		playerHealth = Transform.FindObjectOfType<PlayerHealth> ();
	}
	
	public void OnTriggerEnter2D(Collider2D collider)
	{

		if(collider.gameObject.GetComponent<Player>()){

				playerHealth.GainHeart();
				
			GameObject.Destroy (gameObject);
			}


	}


}
