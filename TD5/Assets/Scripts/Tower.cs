using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	public GameObject bulletPrefab;
	public float damage = 1.0f;
	public float fireRate = 1.0f;
	public float range = 1.0f;
	public int price = 50;

	private GameObject cannon;
	private Vector3 currentDirection;
	private float lastFireTime = 0.0f;

	private List<Enemy> enemiesInRange;

	// Use this for initialization
	void Start () {
		cannon = transform.FindChild ("Cannon").gameObject;
		currentDirection = Vector3.down;

		enemiesInRange = new List<Enemy> ();
	}
	
	// Update is called once per frame
	void Update () {
		enemiesInRange.RemoveAll (e => e == null);

		float min = float.MaxValue;
		Enemy enemy = null;
		foreach (Enemy e in enemiesInRange) {
			float dist = e.GetDistanceToEnd ();
			if (dist < min) {
				enemy = e;
				min = dist;
			}
		}

		// enemy = enemies.Where(x => x.Health >= 50).FirstOrDefault();
		if (enemy != null) {
			Vector3 dir = enemy.transform.position - transform.position;
			Quaternion rot = Quaternion.FromToRotation (currentDirection, dir);
			currentDirection = dir;

			cannon.transform.Rotate(0 ,0, rot.eulerAngles.z);

			if (Time.time > lastFireTime + 1.0f / fireRate) { 
				Fire (enemy.GetComponent<Enemy>());
			}
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		Enemy enemy = other.GetComponent<Enemy> ();
		if (enemy != null) {
			enemiesInRange.Add (enemy);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		Enemy enemy = other.GetComponent<Enemy> ();
		if (enemy != null) {
			enemiesInRange.Remove (enemy);
		}
	}

	void Fire (Enemy target) {
		GameObject go = GameObject.Instantiate (bulletPrefab, transform.position, Quaternion.identity);
		Projectile proj = go.GetComponent<Projectile> ();
		proj.Init (target, this.damage);

		lastFireTime = Time.time;
	}
}
