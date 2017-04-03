using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public Enemy target;
	public float speed;
	public float damage;

	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	public void Init(Enemy target, float damage) {
		this.target = target;
		this.damage = damage;
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs(transform.position.x) > 10 ||  Mathf.Abs(transform.position.y) > 10 ) {
			Destroy (gameObject);
		} 
	
		if (target != null && target.gameObject.activeInHierarchy) {
			Vector3 dir = target.transform.position - transform.position;
			dir = dir.normalized * speed;
			rigidBody.velocity = new Vector2(dir.x, dir.y);
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		
		Enemy target = other.GetComponent<Enemy> ();

		if (target != null) {
			target.Hit (this.damage);
			Destroy (this.gameObject);
		}
	}
}
