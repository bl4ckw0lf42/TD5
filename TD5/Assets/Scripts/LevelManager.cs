using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public static void LoadLevelStatic(string levelName) {
		SceneManager.LoadScene (levelName);
	}

	public void LoadLevel(string levelName) {
		SceneManager.LoadScene (levelName);
	}

	public void Exit() {
		Application.Quit ();
	}

	public void GameOver() {
		SceneManager.LoadScene ("Game Over");
	}

	public void Win() {
		SceneManager.LoadScene ("Win");
	} 
}
