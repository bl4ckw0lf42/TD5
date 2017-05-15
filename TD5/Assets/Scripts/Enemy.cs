using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private const float EPSILON = 0.1f;

	public float speed = 1.0f;
	public float maxLife = 10.0f;

	public int value = 1;
	public int strength = 1;

	private float life;


	private GameManager gm;

	private IEnumerator pathEnumerator;
	private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		life = maxLife;

		gm = GameObject.FindObjectOfType<GameManager> ().GetComponent<GameManager>();

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
				OnEndOfPath();
			}
		}
	}

	public float GetDistanceToEnd() {
		Transform t = pathEnumerator.Current as Transform;
		return Vector3.Distance(targetPosition, transform.position) + t.GetComponent<CheckPoint>().distanceToEnd;
	}

	public void Hit(float damage) {
	
		life -= damage;
		if (life <= 0.0f) {
			OnKilledByTower();
		}
	}

	private void OnKilledByTower() {
		gm.AddMoney (this.value);
		Destroy (this.gameObject);
	}

	private void OnEndOfPath() {
		gm.RemoveLives (this.strength);
		Destroy (this.gameObject);
	}
}
