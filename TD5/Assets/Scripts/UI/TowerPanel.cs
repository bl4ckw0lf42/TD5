using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateTowerPlaceholders (int money) {
		foreach (Transform child in transform) {
			child.GetComponent<TowerPlaceHolder> ().UpdateTowerPlaceHolder(money);
		}
	}
}
