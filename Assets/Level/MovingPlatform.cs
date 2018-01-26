using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public float speed =1f;
	private Transform[] MovePoints;//index 0 gives MovePointsParentObj position
	private Vector3 nextPoint;
	private int pointIndex = 0;
	// Use this for initialization
	void Start () {
		GameObject	MovePointsParentObj = transform.parent.Find ("Move Points").gameObject;
		MovePoints = MovePointsParentObj.transform.GetComponentsInChildren<Transform> ();
		//nextPoint = MovePoints [1].position;
		SetNextPoint();
	}

	// Update is called once per frame
	void Update () {
		Move ();
	}

	private void Move()
	{

		this.transform.position=	Vector3.MoveTowards (transform.position, nextPoint, speed * Time.deltaTime);

	}

	public void SetNextPoint()
	{
//		Debug.Log ("Next Point");
		pointIndex++;
		if (pointIndex > MovePoints.Length - 1) {
			pointIndex = 1;
		}

		nextPoint = MovePoints [pointIndex].position;

	}
}
