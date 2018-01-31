using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailChangeDirection : MonoBehaviour {

	public bool down;
	public bool right;
	public bool up;
	public bool left;



	private Snail.DIRECTION direction;
	private Snail snail;
	private bool triggerd=false;
	// Use this for initialization
	void Start () {

		//get enemy sybling
		foreach (Transform child in transform.parent) 
		{
			if (child.gameObject.GetComponent<Snail> ()) {
				snail = child.gameObject.GetComponent<Snail> ();
			}
		}

		if (down) {
			direction = Snail.DIRECTION.Down;
		} else if (up) {
			direction = Snail.DIRECTION.Up;
		} else if (left) {
			direction = Snail.DIRECTION.Left;
		} else if (right) {
			direction = Snail.DIRECTION.Right;
		} 

	}

	public void OnTriggerEnter2D(Collider2D collider)
	{
		if (triggerd) {
			return;
		}

		Snail collidingSnail = collider.gameObject.GetComponent<Snail> ();
		if (collidingSnail != snail) {
			return;
		}
		triggerd = true;

		snail.gameObject.transform.position = this.transform.position;
		snail.ChangeDirection (direction);


			Invoke ("ResetTrigger", 3);


	}

	void ResetTrigger()
	{
		triggerd = false;
	}
}
