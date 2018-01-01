using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangDirection : MonoBehaviour {

	[Tooltip("Set to true to only trigger once")]
	public bool oneOff=false;

	Enemy enemy;
	private bool triggerd=false;
	// Use this for initialization
	void Start () {
		foreach (Transform child in transform.parent) 
		{
			if (child.gameObject.GetComponent<Enemy> ()) {
				enemy = child.gameObject.GetComponent<Enemy> ();
			}
		}


	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnTriggerEnter2D(Collider2D collider)
	{
		if (triggerd) {
			return;
		}

		Enemy collidingEnemy = collider.gameObject.GetComponent<Enemy> ();
		if (collidingEnemy != enemy) {
			return;
		}


		triggerd = true;
		enemy.ChangeDirection ();

		if (!oneOff) {
			Invoke ("ResetTrigger", 1);
		}

	}

	void ResetTrigger()
	{
		triggerd = false;
	}
}
