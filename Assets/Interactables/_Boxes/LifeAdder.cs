using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeAdder : MonoBehaviour {


	public void AddLife()
	{

		Transform.FindObjectOfType<PlayerLives> ().AddLife ();
	}
}
