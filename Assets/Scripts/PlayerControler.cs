using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {





	private Player player;
	// Use this for initialization
	void Start () {
		
		player = gameObject.GetComponent<Player> ();
		//to do: require player script.
	}
	
	// Update is called once per frame
	void Update () {



		if (Input.GetKey (KeyCode.RightArrow) || Input.GetAxis("Left Joystick")>0) {

			player.MoveRight ();
		} else if (Input.GetKey (KeyCode.LeftArrow) || Input.GetAxis("Left Joystick")<0) {

			player.MoveLeft ();
		} 



		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) ||
			Input.GetButtonDown("A Button")) {

			player.Jump ();

		}

		if (Input.GetKeyDown(KeyCode.Z)||Input.GetButtonDown ("X Button")) {
			player.StartRunning();
		}

		if (Input.GetKeyUp(KeyCode.Z)||Input.GetButtonUp ("X Button")) {
			player.StopRunning();
		}


	}//end of update()


}
