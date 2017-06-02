using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour {

	void OnTriggerExit2D(Collider2D collider) {
		if (collider.GetComponent<Projectile> () != null) {
			Destroy (collider.gameObject);
		}

		if (collider.GetComponent<TowerPlaceHolder> () != null) {
			collider.GetComponent<TowerPlaceHolder> ().canPlaceTower = false;
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.GetComponent<TowerPlaceHolder> () != null) {
			collider.GetComponent<TowerPlaceHolder> ().canPlaceTower = true;
		}
	}


}
