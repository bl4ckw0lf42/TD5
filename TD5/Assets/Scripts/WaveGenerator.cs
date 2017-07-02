using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour {

	public float timeBetweenWaves = 30.0f;
	public bool areWavesLeft = true;

	private Wave currentWave;
	private float lastWaveEndTime;
	private IEnumerator waveEnumerator;


	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		lastWaveEndTime = Time.time;
		waveEnumerator = transform.GetEnumerator ();
		levelManager = GameObject.Find ("Level Manager").GetComponent<LevelManager>();
	}

	// Update is called once per frame
	void Update () {
		if (areWavesLeft) {
			if (lastWaveEndTime + timeBetweenWaves <= Time.time) {
				SpawnNextWave ();
			}
		} else {
			if (!currentWave.AreEnemiesLeft()) {
				if (GameObject.FindObjectOfType<Enemy> () == null) {
					levelManager.Win ();
				}
			}
		}

	}

	public void SpawnNextWave() {
		if (waveEnumerator.MoveNext ()) {
			Transform next = waveEnumerator.Current as Transform;
			currentWave = next.GetComponent<Wave> ();
			currentWave.gameObject.SetActive (true);
			lastWaveEndTime = Time.time;
		} else {
			areWavesLeft = false;
		}
	}

	bool isCurrentWaveActive() {
		if (currentWave != null)
			return currentWave.AreEnemiesLeft();
		return false;
			
	}

	public int GetSecondsTilNextWave() {
		float timeToNext = lastWaveEndTime + timeBetweenWaves;
		float timeLeft = timeToNext - Time.time;
		return (int)Mathf.Round(timeLeft);
	}

	public void SpawnEarly() {
	}


}
