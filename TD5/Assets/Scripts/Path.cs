using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {

	void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		for (int i = 0; i < transform.childCount; i++) {
			if (i > 0) {
				Gizmos.DrawLine (transform.GetChild (i - 1).position, transform.GetChild (i).position);
			}
		}
		Gizmos.color = Color.white;
	}
}
