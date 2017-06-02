using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour {

	public Image fadePanel;
	public float fadeTime = 2.5f;
	public float autoLoadTime = 5.0f;

	private float elapsed;

	// Use this for initialization
	void Start () {
		elapsed = 0.0f;
		Invoke ("LoadMainMenu", autoLoadTime);
	}
	
	// Update is called once per frame
	void Update () {
		if (elapsed < fadeTime) {
			elapsed += Time.deltaTime;
			Color clr = fadePanel.color;
			clr.a = 1.0f - elapsed/fadeTime;
			fadePanel.color = clr;
		}
	}

	private void LoadMainMenu() {
		LevelManager.LoadLevelStatic ("Main Menu");
	}
}
