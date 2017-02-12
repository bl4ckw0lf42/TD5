using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private const float EPSILON = 0.1f;

	public float speed = 1.0f;

	private IEnumerator pathEnumerator;
	private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		Path path = FindObjectOfType<Path> ();
		pathEnumerator = path.transform.GetEnumerator();
		pathEnumerator.MoveNext ();
		Transform t = pathEnumerator.Current as Transform;
		transform.position = t.position;
		pathEnumerator.MoveNext ();
		t = pathEnumerator.Current as Transform;
		targetPosition = t.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = targetPosition - transform.position;
		transform.position += dir.normalized * speed * Time.deltaTime;

		if (Vector3.Distance (transform.position, targetPosition) < EPSILON) {
			if (pathEnumerator.MoveNext ()) {
				Transform t = pathEnumerator.Current as Transform;
				targetPosition = t.position;
			} else {
				Destroy (gameObject);
			}
		}
	}
}
