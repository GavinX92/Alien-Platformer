using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {


	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlucked_";
		

	public static void SetMasterVolume(float volume)
	{
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {

			Debug.LogError ("Master volume out of range.");
		}

	}//end of SetMasterVolume()


	public static float GetMasterVolume(){

		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);

	}


	public static void UnlockLevel(int level){

		if (level <= SceneManager.sceneCountInBuildSettings - 1) {

			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString (), 1);// 1 = true
		} else {

			Debug.LogError ("Trying to unlock level not in build order");
		}

	}

	public static bool IsLevelUnlocked(int level)
	{
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {

			int levelUnlocked = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString ());// 1 = true

			if(levelUnlocked==1)
			{
				return true;
				}
			else
			{
				return false;
			}

		} else {
			Debug.LogError ("Trying to check unlocked level; not in build order");

			return false;
		}
	}// end of IsLevelUnlocked


	public static void SetDifficulty(float difficulty)
	{
		if (difficulty >= 1 && difficulty <= 3) {
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty);
		} else {

			Debug.LogError ("Difficulty out of range.");
		}
	}

	public static float GetDifficulty()
	{

		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}
}
