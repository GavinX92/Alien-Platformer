using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBoxCoin : MonoBehaviour {

	//TO DO: Rename to coin box

	public int numberOfCoins = 1;

	private Animator animator;
	private PlayerCoins playerCoins;


	private BoxEnemyBouncer boxEnemyBouncer;
	// Use this for initialization
	void Start () {
		playerCoins = Transform.FindObjectOfType<PlayerCoins> ();
		animator = GetComponent<Animator> ();

		boxEnemyBouncer = GetComponentInChildren<BoxEnemyBouncer> ();
	}

	public void OnTriggerEnter2D(Collider2D collider)
	{


		print ("triggered");
		if (collider.gameObject.GetComponent<Player> ()) {

			numberOfCoins--;
			if (numberOfCoins == 0) {
				animator.SetTrigger ("last hit trigger");
			} else {
				animator.SetTrigger ("hit trigger");

			}
			boxEnemyBouncer.KillEnemy ();
		
		}
	}

	public void AddCoin()
	{
		
				playerCoins.AddCoin ();
	}

//	public void ResetHitBool()
//	{
//		//using bool as trigger to stop double trigger on short animation
//		animator.SetBool ("hit bool", false);
//
//	}
//
//	private void ResetTrigger()
//	{
//		Debug.Log("ResetTrigger()");
//		triggered = false;
//	}



}
