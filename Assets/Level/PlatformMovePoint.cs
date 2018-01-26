using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovePoint : MonoBehaviour {


	private MovingPlatform movingPlatform;
	private bool triggered=false;
	// Use this for initialization
	void Start () {
		movingPlatform = transform.parent.transform.parent.GetComponentInChildren<MovingPlatform> ();

	}

	public void OnTriggerEnter2D(Collider2D collider) {

		if (triggered) {
			return;
		}

		if (collider.gameObject == movingPlatform.gameObject) {
			
			movingPlatform.SetNextPoint ();
			triggered = true;
			Invoke ("ResetTrigger", 1);
		}
	}

	private void ResetTrigger()
	{

		triggered = false;
	}
}
