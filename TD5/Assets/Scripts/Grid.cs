using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grid : MonoBehaviour {

	public int CellsX = 1;
	public int CellsY = 1;
	public float Width = 1.0f;
	public float Height = 1.0f;
	public GameObject GridCellTemplate;
	public Rect[] PreBlockList;

	private GameObject gridCellsContainer;
	private List<GridCell> gridCells = new List<GridCell>();
	private Vector3 lowerLeftCellPos;
	private Vector3 cellSize;

	// Use this for initialization
	void Start () {
		cellSize = new Vector3 (Width / CellsX, Height / CellsY, 1.0f);
		lowerLeftCellPos = transform.position - new Vector3(Width/2, Height/2, 0.0f) + cellSize/2;

		gridCellsContainer = new GameObject ("GridCellsContainer");
		gridCellsContainer.transform.parent = transform;
		gridCellsContainer.SetActive (false);

		createAllCells();

		Preblock ();


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Preblock() {
		foreach (var cell in gridCells) {
			foreach (var rect in PreBlockList) {
				if (rect.Contains (cell.transform.position)) {
					cell.Blocked = true;
				}
			}
		}

	}

	public void ShowGridCells (Rect hitBox) {
		gridCellsContainer.SetActive (true);

	}

	public bool UpdateHighLight(Rect hitBox) {
		List<GridCell> hoverCells = new List<GridCell> ();
		foreach (GridCell cell in gridCells) {
			cell.Highlighted = false;
			if (!cell.Blocked && hitBox.Contains (cell.transform.position))
				hoverCells.Add (cell);
		}

		if (hoverCells.Count == 4) {
			hoverCells.ForEach (c => c.Highlighted = true);
			return true;
		}
		return false;
	}

	public Vector3 BlockCells(Rect hitBox) {
		List<GridCell> hoverCells = new List<GridCell> ();
		foreach (GridCell cell in gridCells) {
			cell.Highlighted = false;
			if (!cell.Blocked && hitBox.Contains (cell.transform.position))
				hoverCells.Add (cell);
		}

		Vector3 snapPos = Vector3.zero;
		hoverCells.ForEach (c => {
			snapPos += c.transform.position;
			c.Blocked = true;
		});
		snapPos /= 4.0f;

		return snapPos;
	}

	public void HideGridCells () {
		gridCellsContainer.SetActive (false);
	}

	public void createAllCells() {
		for (int y = 0; y < CellsY; y++) {
			for (int x = 0; x < CellsX; x++) {
				int index = y * CellsX + x;
				gridCells.Add(createGridCell());
				Vector3 pos = cellSize;
				pos.Scale (new Vector3 (x, y, 0.0f));
				pos += lowerLeftCellPos;
				gridCells [index].transform.position = pos;
			}
		}
	}

	GridCell createGridCell() {
		GameObject cell = GameObject.Instantiate (GridCellTemplate, gridCellsContainer.transform);
		cell.transform.localScale = cellSize;
		return cell.GetComponent<GridCell>();
	}

	void OnDrawGizmos() {
		Gizmos.color = new Color (0.0f, 0.0f, 0.0f, 0.25f);
		Vector3 lowerLeft = new Vector3 (-Width/2.0f, -Height/2.0f, 0.0f);
		Vector3 up = Vector3.up * Height;
		Vector3 right = Vector3.right * Width;

		float stepX = Width / CellsX;
		Vector3 bottom = lowerLeft;
		Gizmos.DrawLine (transform.TransformPoint(bottom), transform.TransformPoint(bottom + up));
		for (int x = 0; x < CellsX; x++) {
			bottom.x += stepX;
			Gizmos.DrawLine (transform.TransformPoint(bottom), transform.TransformPoint(bottom + up));
		}

		float stepY = Height / CellsY;
		Vector3 left = lowerLeft;
		Gizmos.DrawLine (transform.TransformPoint(left), transform.TransformPoint(left + right));
		for (int y = 0; y < CellsY; y++) {
			left.y += stepY;
			Gizmos.DrawLine (transform.TransformPoint(left), transform.TransformPoint(left + right));
		}
	}
}
