using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour {

	public float timeBetweenWaves = 30.0f;

	private Wave currentWave;
	private float lastWaveEndTime;
	private IEnumerator waveEnumerator;

	// Use this for initialization
	void Start () {
		lastWaveEndTime = Time.time;
		waveEnumerator = transform.GetEnumerator ();
	}

	// Update is called once per frame
	void Update () {
		if (!isCurrentWaveActive() && lastWaveEndTime + timeBetweenWaves >= Time.time) {
			SpawnNextWave ();
		}
	}

	public void SpawnNextWave() {
		if (waveEnumerator.MoveNext ()) {
			Transform next = waveEnumerator.Current as Transform;
			currentWave = next.GetComponent<Wave> ();
			currentWave.gameObject.SetActive (true);
		}
	}

	bool isCurrentWaveActive() {
		if (currentWave != null)
			return currentWave.AreEnemiesLeft();
		return false;
			
	}
}
