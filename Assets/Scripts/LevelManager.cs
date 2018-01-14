using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public  const string START_MENU_NAME = "01a_Start Menu";
	public const string OPTIONS_MENU_NAME = "01b_Options";
	public const string WIN_SCREEN_NAME = "03a Win Screen";
	public const string LOSE_SCREEN_NAME = "03b Lose Screen";

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene(name);
	}

	public void LoadNextLevel()
	{

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

}
