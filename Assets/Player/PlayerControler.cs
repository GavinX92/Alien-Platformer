using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerControler : MonoBehaviour {



	public bool disableUpArrowJump =false;
	//public float mobileJoystickDeadSpace=0.0f;

	private bool isAcceptingInput=true;
	private Player player;

	private bool actionButtonDown=false;

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
	

		if (CrossPlatformInputManager.GetAxis ("Horizontal") < 0) {
			player.MoveLeft ();
		}
		else if(CrossPlatformInputManager.GetAxis ("Horizontal") > 0)
		{
			player.MoveRight();

		}
			

		if(CrossPlatformInputManager.GetButtonDown("Action")){
			player.UseEquipedItem();
			actionButtonDown = true;
			print ("action button down = " + actionButtonDown.ToString ());
		}
			
		if(CrossPlatformInputManager.GetButtonUp("Action")){
			
			actionButtonDown = false;
			print ("action button down = " + actionButtonDown.ToString ());
		}

		if (CrossPlatformInputManager.GetButtonDown ("Jump")) {
			player.Jump ();

		}
				

	}//end of update()

	public void SetISAcceptingInput(bool isAcceptingInput)
	{

		this.isAcceptingInput = isAcceptingInput;

	}

	public bool GetActionButtonDown()
	{
		return actionButtonDown;

	}
}
