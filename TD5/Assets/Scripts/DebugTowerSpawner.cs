using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTowerSpawner : MonoBehaviour {

	public GameObject towerPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.T)) {
			Camera cam = FindObjectOfType<Camera> ();
			Vector3 spawnPos = cam.ScreenToWorldPoint (Input.mousePosition);
			spawnPos.z = 0.0f;
			Instantiate (towerPrefab, spawnPos, Quaternion.identity);
		}
	}
}
