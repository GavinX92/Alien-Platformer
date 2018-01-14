using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager{


	const string MUSIC_VOLUME_KEY = "music_volume";

	const string SOUND_FX_VOLUME_KEY = "sound_fx_volume";



		

	public static void SetMusicVolume(float volume)
	{
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (MUSIC_VOLUME_KEY, volume);
		} else {

			Debug.LogError ("Music volume out of range.");
		}

	}//end of SetMusicVolume()

	public static void SetSoundFXvolume(float volume)
	{
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (SOUND_FX_VOLUME_KEY, volume);
		} else {

			Debug.LogError ("Sound FX volume out of range.");
		}

	}

	public static float GetMusicVolume(){



		if (PlayerPrefs.HasKey (MUSIC_VOLUME_KEY)) {
			return PlayerPrefs.GetFloat (MUSIC_VOLUME_KEY);
		} else {
			return 1;
		}

	}

	public static float GetSoundFXvolume(){
		if(PlayerPrefs.HasKey(SOUND_FX_VOLUME_KEY)){
			return PlayerPrefs.GetFloat (SOUND_FX_VOLUME_KEY);
			}else
			{
				return 1;
			}


	}

	public static void DeletePrefs()
	{

		PlayerPrefs.DeleteAll ();

		Debug.Log ("Player prefrences deleted");
	}
		
}
