using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEnemyBouncer : MonoBehaviour {

	private Enemy enemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.GetComponent<Enemy>())
			{

			enemy = collider.gameObject.GetComponent<Enemy> ();
			Debug.Log ("Enemy = " + enemy.name);
			}
	}

	public void OnTriggerStay2D(Collider2D collider)
	{
		
	}
	public void OnTriggerExit2D(Collider2D collider)
	{
		enemy = null;
		Debug.Log ("Enemy = null");
	}

	public void KillEnemy()
	{
		if (enemy) {
			enemy.EnemyDamaged ();
		}
		print ("kill");
	}
}
