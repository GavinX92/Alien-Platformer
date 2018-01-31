using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour {

	public enum DIRECTION{Up,Down,Left,Right};
	private Enemy enemy;
	private BouncePlayerOnDeath bouncePlayer;

	//private DIRECTION currentDirection=DIRECTION.Left;


	// Use this for initialization
	void Start () {
		enemy = GetComponent<Enemy> ();
		bouncePlayer = GetComponent<BouncePlayerOnDeath> ();
	
	}
		
	 
	public void GetUp()
	{
		enemy.SetIsDead (false); 
		bouncePlayer.setPlayerBounced (false);
	}
		
	public void ChangeDirection(DIRECTION direction)
	{
		

		if (direction==DIRECTION.Down) {
			//go down
		//	currentDirection=DIRECTION.Down;
			enemy.SetXdir (0);
			enemy.SetYdir (-1);
			enemy.SetRotation (new Vector3 (0, 0, 90));
//			print ("down");

		} else if (direction==DIRECTION.Right) {
			//go right
		//	currentDirection=DIRECTION.Right;
			enemy.SetXdir (1);
			enemy.SetYdir (0);
			enemy.SetRotation (new Vector3 (0, 0, 180));

		//	print ("right");
		} else if (direction==DIRECTION.Up) {
		
			//go up
			//currentDirection=DIRECTION.Up;
			enemy.SetXdir (0);
			enemy.SetYdir (1);
			enemy.SetRotation (new Vector3 (0, 0, 270));

		//	print ("up");
		}else if (direction==DIRECTION.Left) {

			//go left
			//currentDirection=DIRECTION.Left;
			enemy.SetXdir(-1);
			enemy.SetYdir (0);
			enemy.SetRotation (new Vector3 (0, 0, 0));
		//	print ("left");
		}


	}


	public static void ResetSnails()
	{
		Snail[] snails = Transform.FindObjectsOfType<Snail> ();

		foreach (Snail snail in snails) {

			//snail.ChangeDirection (DIRECTION.Left);
		}

	}
}
