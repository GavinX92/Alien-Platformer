using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawner : MonoBehaviour {


	private AudioSource audioSource;
	private GameObject player;
	private PlayerRespawnPoint playerRespawnPoint;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		player = GameObject.Find ("Player");
	}

	public void RespawnPlayer()
	{
		player.SetActive (false);
		audioSource.Play ();
		float lenght = audioSource.clip.length;
		Invoke ("ResetPlayerAndEnemyPositions", lenght);

	}

	private void ResetPlayerAndEnemyPositions()
	{
		PlayerHealth playerHealth = Transform.FindObjectOfType<PlayerHealth> ();
		playerHealth.SetHealth (3);

		player.SetActive (true);
		player.transform.position = playerRespawnPoint.transform.position;


		Enemy.RespawnEnemies ();
	}


	public void SetPlayerRespawnPoint(PlayerRespawnPoint playerRespawnPoint)
		{
			this.playerRespawnPoint = playerRespawnPoint;
	
		}
}
