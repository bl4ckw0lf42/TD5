using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

	public float timeBetweenEnemies = 2.0f;

	private IEnumerator enemyEnumerator;
	private bool areEnemiesLeft = true;
	private float lastSpawnTime;

	// Use this for initialization
	void Start () {
		enemyEnumerator = transform.GetEnumerator ();
		lastSpawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (areEnemiesLeft) {
			if (lastSpawnTime + timeBetweenEnemies <= Time.time) {
				if (enemyEnumerator.MoveNext ()) {
					Transform next = enemyEnumerator.Current as Transform;
					next.gameObject.SetActive (true);
					lastSpawnTime = Time.time;
				} else {
					areEnemiesLeft = false;
				}
			}
		}
	}

	public bool AreEnemiesLeft() {
		return areEnemiesLeft;
	}
}
