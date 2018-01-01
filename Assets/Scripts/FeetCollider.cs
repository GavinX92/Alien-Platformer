using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCollider : MonoBehaviour {

	private GameObject playerObj;
	private Player playerScript;
	private Vector3 offsetFromPlayer;

	//private JumpableSurface[] jumpableSurfaces;
	//private List<Collider2D> jumpableSurfaceColliders;
	//private Collider2D myCollider;
	// Use this for initialization
	void Start () {

		 playerObj = gameObject.transform.parent.gameObject;
		if (!playerObj) {Debug.LogError("Can't find parent.");}
		playerScript = playerObj.GetComponent<Player> ();


		offsetFromPlayer =  playerObj.transform.position-this.transform.position;

//		jumpableSurfaces = GameObject.FindObjectsOfType<JumpableSurface> ();
//		foreach (JumpableSurface jumpableSurface in jumpableSurfaces) {
//			GameObject obj =jumpableSurface.gameObject;//GetComponent<BoxCollider2D> ();
//			jumpableSurfaceColliders.Add(jumpableSurface.gameObject.GetComponent<Collider2D>());
//
//			myCollider = gameObject.GetComponent<Collider2D> ();
//		}
	}

	// Update is called once per frame
	void Update () {
		this.transform.position = playerObj.transform.position - offsetFromPlayer;
		gameObject.transform.rotation = Quaternion.identity;

//		bool inAir = true;
//		foreach (Collider2D collider in jumpableSurfaceColliders) {
//
//			if (myCollider.IsTouching (collider)) {
//				inAir = false;
//			}
//		}
//		playerScript.setJumping (inAir);

	}


	public void OnTriggerEnter2D(Collider2D collider) {

		if (collider.gameObject == playerObj) {
			return;
		}

		if (collider.gameObject.GetComponent<JumpableSurface> ()) {
			playerScript.setJumping (false);
		}


	}

	void OnTriggerStay2D(Collider2D collider){

//		print ("stay");
		if (collider.gameObject == playerObj) {
			return;
		}

		if (collider.gameObject.GetComponent<JumpableSurface> ()) {
			playerScript.setJumping (false);
		}


	}

	public void OnTriggerExit2D(Collider2D collider) {

		if (collider.gameObject == playerObj) {
			return;
		}

		if (collider.gameObject.GetComponent<JumpableSurface> ()) {
			playerScript.setJumping (true);
		}


	}


}
