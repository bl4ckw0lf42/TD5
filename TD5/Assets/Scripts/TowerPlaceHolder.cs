using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlaceHolder : MonoBehaviour {


	private GameObject tower;
	private UiUpdater ui;

	// Use this for initialization
	void Start () {
		ui = GameObject.FindObjectOfType<UiUpdater> ().GetComponent<UiUpdater> ();
		tower = transform.GetChild (0).gameObject;
		
	}
	
	// Update is called once per frame
	void OnMouseDown() {

		ui.SetDetailsObject (tower);
	}
}
