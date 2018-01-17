using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionToStart : MonoBehaviour {


	public float transitionTime = 10;
	// Use this for initialization
	void Start () {

		Invoke ("ToStart", transitionTime);
	}
	
	
	private void ToStart(){

		LevelManager.LoadLevel (LevelManager.START_MENU_NAME);
	}
}
