using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartAdder : MonoBehaviour {



	public void AddHeart()
	{

		Transform.FindObjectOfType<PlayerHealth>().GainHeart();
	}
}
