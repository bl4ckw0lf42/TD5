using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public Enemy target;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null || !target.gameObject.activeInHierarchy) {
			Destroy (gameObject);
			return;
		}

		Vector3 dir = target.transform.position - transform.position;
		transform.position += dir.normalized * speed * Time.deltaTime;
	}
}
