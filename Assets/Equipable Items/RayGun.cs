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
	
	// Update is called once per frame
	void Update () {
		
	}


	public void Shoot(int xDir)
	{
		spriteRenderer.enabled = true;
		GameObject bullet =	Instantiate (bulletPrefab,this.transform.position, Quaternion.identity) as GameObject;
		bullet.GetComponent<Bullet> ().SetXdir (xDir);

		Invoke ("HideRaygun", 0.3f);


	}

	private void HideRaygun()
	{
		spriteRenderer.enabled = false;

	}
}
