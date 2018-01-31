using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella : MonoBehaviour {


//	public bool striking=false;

	public Sprite openSprite;
	public Sprite closedSprite;
	public float reducedGravity = 0.01f;



//	private Animator animator;
	private SpriteRenderer spriteRenderer;
	private PlayerControler playerControler;
	private Player player;
	private bool isOpen = true;
	//private GameObject pushPoint;
	// Use this for initialization
	void Start () {
		//animator = GetComponent<Animator> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		playerControler = GetComponentInParent<PlayerControler> ();
		player = GetComponentInParent<Player> ();
		//pushPoint = transform.Find ("Push Point").gameObject;

	}
	
	// Update is called once per frame
	void Update () {
//		if (striking) {
//			//print ("striking");
//			animator.SetBool ("action button down", playerControler.GetActionButtonDown ());
//			animator.SetBool ("player is jumping", player.IsJumping ());
//		}

		this.SetIsOpen (!playerControler.GetActionButtonDown());

		
	}
	public void Activate()
	{

		spriteRenderer.enabled = true;
		isOpen = true;
	}

	public void Deactivate()
	{

		spriteRenderer.enabled = false;
	}
//	public void Strike()
//	{
//		striking = true;
//		animator.SetTrigger ("strike trigger");
//		//Invoke ("ResetStrike", 1);
//
//
//	}

	public void ToggleOpenClose()
	{
//		isOpen= !isOpen;
//
//		if (isOpen) {
//			spriteRenderer.sprite = openSprite;
//		} else {
//			spriteRenderer.sprite = closedSprite;
//		}
//
//		if (!isOpen) {
//			Invoke ("ToggleOpenClose", 0.1f);
//		}
	}

	public void SetIsOpen(bool open)
	{
		this.isOpen = open;

		if (isOpen) {
			spriteRenderer.sprite = openSprite;
		} else {
			spriteRenderer.sprite = closedSprite;
		}
	}
	public void OnTriggerEnter2D(Collider2D collider)
	{
//		Enemy enemy = collider.gameObject.GetComponent<Enemy> ();
//
//		if (enemy) {
//			//enemy.EnemyDamaged ();
//			//enemy.EnemyFreeze (3);
//			//enemy.gameObject.transform.position = pushPoint.transform.position;
////			float x =pushPoint.transform.TransformPoint(pushPoint.transform.position).x;
////			print ("x ="+ x);
////			enemy.Knockback(0.1f,x);
//			Vector2 newPosition = enemy.transform.position;
//			newPosition.x = pushPoint.transform.position.x;
//			enemy.transform.position = newPosition;
//		}
	}

	public void OnTriggerStay2D(Collider2D collider)
	{

		Enemy enemy = collider.gameObject.GetComponent<Enemy> ();

		if (enemy) {
			enemy.changeDirectionOnEnemyHit = false;
			float yRotation = player.transform.rotation.y;
			int xDir;
			if (yRotation == 0) {
				 xDir = 1;
			} else {
				xDir = -1;
			}


			float knockbackPower = 5;
			float x = enemy.transform.position.x;
			float y = enemy.transform.position.y;
			x += xDir * knockbackPower * Time.deltaTime;

			enemy.transform.position = new Vector3 (x, y);	
		}
	}

	public void OnTriggerExit2D(Collider2D collider)
	{
		Enemy enemy = collider.gameObject.GetComponent<Enemy> ();

		if (enemy) {
			enemy.changeDirectionOnEnemyHit = true;

		}
	}

	public void ResetStrike()
	{

		//striking = false;
	}


	public bool GetIsOpen()
	{

		return isOpen;
	}

}
