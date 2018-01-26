using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateSetter : MonoBehaviour {

	public int targetFrameRate=30;
	// Use this for initialization
	void Start () {
		Application.targetFrameRate = targetFrameRate;
	}
	

}
