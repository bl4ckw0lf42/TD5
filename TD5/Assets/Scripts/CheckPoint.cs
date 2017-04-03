using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

	public float distanceToEnd;

	void OnDrawGizmos() {
		int childIndex = transform.GetSiblingIndex ();
		if (childIndex == 0) {
			Gizmos.color = Color.green;
		} else if (childIndex == transform.parent.childCount - 1) {
			Gizmos.color = Color.red;
		} else {
			Gizmos.color = Color.white;
		}
		Gizmos.DrawWireSphere (transform.position, 0.25f);
	}
}
