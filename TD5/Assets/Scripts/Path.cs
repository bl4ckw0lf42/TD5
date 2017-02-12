using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {

	public Vector3 InterpolatePosition(float s) {


		return Vector3.zero;
	}

	void OnDrawGizmos() {
		for (int i = 0; i < transform.childCount; i++) {
			if (i==0) Gizmos.color = Color.green;
			else if(i==transform.childCount-1) Gizmos.color = Color.red;
			else Gizmos.color = Color.white;
			Gizmos.DrawWireSphere (transform.GetChild (i).position, 0.25f);
			if (i > 0) {
				Gizmos.color = Color.yellow;
				Gizmos.DrawLine (transform.GetChild (i - 1).position, transform.GetChild (i).position);
			}
		}
		Gizmos.color = Color.white;
	}
}
