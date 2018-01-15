using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionToStart : MonoBehaviour {

	public LevelManager levelManager;
	public float transitionTime = 10;
	// Use this for initialization
	void Start () {

		Invoke ("ToStart", transitionTime);
	}
	
	
	private void ToStart(){

		levelManager.LoadLevel (LevelManager.START_MENU_NAME);
	}
}
