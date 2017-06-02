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

	void Start() {
		CheckPoint last = transform.GetChild (transform.childCount - 1).GetComponent<CheckPoint>();

		for (int i = transform.childCount - 1; i >= 0; i--) {
			CheckPoint cp = transform.GetChild (i).GetComponent<CheckPoint> ();
			float dist = Vector3.Distance (cp.transform.position, last.transform.position);
			cp.distanceToEnd = dist;
			last = cp;
		}
	}

	public List<Rect> GetPathRects() {
		List<Rect> rects = new List<Rect> ();
		for (int i = 0; i < transform.childCount - 1; i++) {
			Transform fromPoint = transform.GetChild (i);
			Transform toPoint = transform.GetChild (i + 1);

		}

		return rects;
	}
}
