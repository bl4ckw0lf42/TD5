using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	public GameObject bulletPrefab;
	public float fireRate = 1.0f;

	private GameObject cannon;
	private Vector3 currentDirection;
	private float lastFireTime = 0.0f;

	// Use this for initialization
	void Start () {
		cannon = transform.FindChild ("Cannon").gameObject;
		currentDirection = Vector3.down;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject enemy = FindObjectOfType<Enemy> ().gameObject;
		Vector3 dir = enemy.transform.position - transform.position;
		Quaternion rot = Quaternion.FromToRotation (currentDirection, dir);
		currentDirection = dir;

		cannon.transform.Rotate(0 ,0, rot.eulerAngles.z);

		if (Time.time > lastFireTime + 1.0f / fireRate) { 
			Fire (enemy.GetComponent<Enemy>());
		}
	}

	void Fire (Enemy target) {
		GameObject go = GameObject.Instantiate (bulletPrefab, transform.position, Quaternion.identity);
		Projectile proj = go.GetComponent<Projectile> ();
		proj.target = target;
		proj.speed = 5.0f;

		lastFireTime = Time.time;
	}
}
