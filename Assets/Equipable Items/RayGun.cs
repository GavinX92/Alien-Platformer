using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGun : MonoBehaviour {


	public GameObject bulletPrefab; 



	private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	public void Activate()
	{

		spriteRenderer.enabled = true;
	}

	public void Deactivate()
	{

		spriteRenderer.enabled = false;
	}

	public void Shoot(int xDir)
	{
		spriteRenderer.enabled = true;
		GameObject bullet =	Instantiate (bulletPrefab,this.transform.position, Quaternion.identity) as GameObject;
		bullet.GetComponent<Bullet> ().SetXdir (xDir);

		//Invoke ("HideRaygun", 0.3f);


	}

	private void HideRaygun()
	{
		spriteRenderer.enabled = false;

	}
}
