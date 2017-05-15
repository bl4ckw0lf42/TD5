using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDetails : MonoBehaviour {

	private UiUpdater ui;
	// Use this for initialization
	void Start () {
		ui = GameObject.FindObjectOfType<UiUpdater> ();
	}
	
	void OnMouseDown() {
		ui.SetDetailsObject (null);
	}
}
