using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerControler : MonoBehaviour {



	public bool disableUpArrowJump =false;
	//public float mobileJoystickDeadSpace=0.0f;

	private bool isAcceptingInput=true;
	private Player player;

	// Use this for initialization
	void Start () {
		
		player = gameObject.GetComponent<Player> ();

		//to do: require player script.
	}
	
	// Update is called once per frame
	void Update () {

		if (!isAcceptingInput) {

			return;
		}
	
//		print (CrossPlatformInputManager.GetAxis ("Horizontal").ToString ());
		if (CrossPlatformInputManager.GetAxis ("Horizontal") < 0) {
			player.MoveLeft ();
		}
		else if(CrossPlatformInputManager.GetAxis ("Horizontal") > 0)
		{
			player.MoveRight();

		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {

			player.Jump ();
		}
			

		if (CrossPlatformInputManager.GetButtonDown ("Jump")) {
			//player.Jump ();
			player.UseEquipedItem();
		}

//		if (Input.GetKey (KeyCode.RightArrow) ){//|| Input.GetAxis("Left Joystick")>0) {
//
//			player.MoveRight ();
//	} else if (Input.GetKey (KeyCode.LeftArrow) ){//|| Input.GetAxis("Left Joystick")<0) {
//
//			player.MoveLeft ();
//		} 
//
//
//
//		if ((Input.GetKeyDown (KeyCode.UpArrow) && !disableUpArrowJump )|| Input.GetKeyDown(KeyCode.Space)){
//	//|| Input.GetButtonDown("A Button")) {
//
//			player.Jump ();
//
//		}
//
//		if (Input.GetKeyDown(KeyCode.Z)){//||Input.GetButtonDown ("X Button")) {
//			player.StartRunning();
//		}
//
//		if (Input.GetKeyUp(KeyCode.Z)){//||Input.GetButtonUp ("X Button")) {
//			player.StopRunning();
//		}


	}//end of update()

	public void SetISAcceptingInput(bool isAcceptingInput)
	{

		this.isAcceptingInput = isAcceptingInput;

	}
}
