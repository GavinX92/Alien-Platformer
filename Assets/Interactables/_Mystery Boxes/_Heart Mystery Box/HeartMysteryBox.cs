using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMysteryBox : MonoBehaviour {

	public GameObject heartPrefab;


	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	public void OnTriggerEnter2D(Collider2D collider)
	{

		animator.SetTrigger ("hit trigger");
	}


	public void AddHeart()
	{
	 
		Transform.FindObjectOfType<PlayerHealth>().GainHeart();
	}

//	public void CreateHeart()
//	{
//
//		GameObject heart = Instantiate (heartPrefab) as GameObject;
//		Vector2 heartPosition = gameObject.transform.position;
//		heartPosition.y += 10;
//		heart.transform.position = heartPosition;
//	}

}
