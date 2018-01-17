using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {



	public float horizontalMoveLine=1;
	public float topMoveLine;
	public float bottomMoveLine;


	public GameObject CameraMinBottomLineObj;//empty object in seen. placed at min camera bottom line. noramally just bellow the bottom floor.
	public GameObject CameraMinLefLineObj;


	private Camera cameraComponent;
	private	GameObject player;
	private bool isFollowingPlayer=true;
	//Vector3 offset;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		if (!player) {Debug.LogError ("Can't find player");}
		cameraComponent = gameObject.GetComponent<Camera> ();
		if (!cameraComponent) {Debug.LogError ("Can't find camera component");}

	}
	
	// Update is called once per frame
	void Update () {
		if (!isFollowingPlayer) {
			return;
		}
		float playerX =player.transform.position.x ;
		float rightLineX =this.transform.position.x + horizontalMoveLine;
		float leftLineX = this.transform.position.x - horizontalMoveLine;

		if (playerX > rightLineX) {

		//	print ("move camera right");
			float distanceFromLine = playerX - rightLineX;

			float x = this.transform.position.x + distanceFromLine;
			float y = this.transform.position.y;
			float z = this.transform.position.z;
			this.transform.position = new Vector3 (x, y, z);

		} else if (playerX < leftLineX) {


			float distanceFromLine = leftLineX-playerX;;

			float x = this.transform.position.x - distanceFromLine;
			float y = this.transform.position.y;
			float z = this.transform.position.z;
			this.transform.position = new Vector3 (x, y, z);

		}

		float playerY = player.transform.position.y;
		float topLineY = this.transform.position.y + topMoveLine;
		float bottomLineY = this.transform.position.y - bottomMoveLine;

		if (playerY > topLineY) {

			float distanceFromLine = playerY - topLineY;

			float x = this.transform.position.x;
			float y = this.transform.position.y+ distanceFromLine;
			float z = this.transform.position.z;
			this.transform.position = new Vector3 (x, y, z);
		} else if (playerY < bottomLineY) {

			float distanceFromLine = bottomLineY-playerY ;

			float x = this.transform.position.x;
			float y = this.transform.position.y- distanceFromLine;
			float z = this.transform.position.z;
			this.transform.position = new Vector3 (x, y, z);
		}

		float cameraBottomViewLine = this.transform.position.y - cameraComponent.orthographicSize;
		float cameraMinBottomLineY = CameraMinBottomLineObj.transform.position.y;

		if (cameraBottomViewLine < cameraMinBottomLineY) {

			float distance = cameraMinBottomLineY-cameraBottomViewLine ;

			float x = this.transform.position.x;
			float y = this.transform.position.y+ distance;
			float z = this.transform.position.z;
			this.transform.position = new Vector3 (x, y, z);
		}

		float cameraLeftViewLine = this.transform.position.x - cameraComponent.orthographicSize * 2;
		float cameraMinLeftLineX = CameraMinLefLineObj.transform.position.x;

		if (cameraLeftViewLine < cameraMinLeftLineX) {

			float distance = cameraMinLeftLineX-cameraLeftViewLine ;

			float x = this.transform.position.x+distance;
			float y = this.transform.position.y;
			float z = this.transform.position.z;
			this.transform.position = new Vector3 (x, y, z);
		}
	}


	public void SetIsFollowingPlayer(bool isFollowingPlayer)
	{
		this.isFollowingPlayer = isFollowingPlayer;


	}
}
