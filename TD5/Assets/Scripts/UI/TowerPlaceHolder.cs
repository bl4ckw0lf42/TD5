using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlaceHolder : MonoBehaviour {

	public bool canPlaceTower;
	public bool canBuyTower;

	private Tower tower;
	private SpriteRenderer darkener;
	private UiUpdater ui;
	private GameManager gm;
	private Grid grid;

	private Vector3 startPos;
	private Rect hitBox = new Rect (Vector2.zero, Vector2.one);

	// Use this for initialization
	void Start () {
		ui = GameObject.FindObjectOfType<UiUpdater> ().GetComponent<UiUpdater> ();
		gm = GameObject.FindObjectOfType<GameManager> ().GetComponent<GameManager> ();
		grid = GameObject.FindObjectOfType<Grid>().GetComponent<Grid>();
		darkener = transform.GetChild (0).GetComponent<SpriteRenderer> ();
		tower = transform.GetChild (1).GetComponent<Tower>();
		tower.enabled = false;
		tower.GetComponent<CircleCollider2D> ().enabled = false;
		startPos = transform.position;
		canPlaceTower = false;
		canBuyTower = false;
		
	}

	void OnMouseDown() {
		ui.SetDetailsObject (tower.gameObject);
		if (canBuyTower) grid.ShowGridCells (default(Rect));
	}

	void OnMouseDrag() {
		if (!canBuyTower)
			return;
		Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		newPos.z = transform.position.z;
		transform.position = newPos;
		hitBox.position = new Vector2 (newPos.x - 0.5f, newPos.y - 0.5f);
		canPlaceTower = grid.UpdateHighLight(hitBox);
	}

	void resetPosition() {
		transform.position = startPos;
	}

	void OnMouseUp() {
		
		resetPosition ();
		grid.HideGridCells ();
		if (canPlaceTower) {
			Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			pos = grid.BlockCells (hitBox);
			pos.z = 0.0f;

			GameObject go = Instantiate (tower.gameObject, pos, Quaternion.identity);
			go.GetComponent<Tower> ().enabled = true;
			go.GetComponent<CircleCollider2D> ().enabled = true;

			gm.RemoveMoney (tower.price);

		}

	}

	void setCanBuy(bool canBuy) {
		if (canBuy != this.canBuyTower) {
			canBuyTower = canBuy;
			Color newClr = darkener.color;
			newClr.a = canBuyTower ? 0.0f : 0.5f;
			darkener.color = newClr;
		}
	}

	public void UpdateTowerPlaceHolder (int money) {
		bool canBuy = tower.price <= money;
		setCanBuy (canBuy);
	}
}
