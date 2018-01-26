using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


	public float speed=1;
	public float freezeDuration=3;
	private int xDir =1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	private void Move()
	{
		float x = gameObject.transform.position.x;
		float y = gameObject.transform.position.y;
		x += xDir * speed * Time.deltaTime;
		//y += yDir * speed * Time.deltaTime;
		gameObject.transform.position = new Vector3 (x, y);	

	}

	public void OnTriggerEnter2D(Collider2D collider)
	{
		Enemy enemy = collider.gameObject.GetComponent<Enemy> ();

		if (enemy) {
			enemy.EnemyFreeze (freezeDuration);

		}

		Destroy (gameObject);

	}


	public void SetXdir(int xDir){
		this.xDir = xDir;
	}
}
