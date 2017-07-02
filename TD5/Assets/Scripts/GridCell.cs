using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour {

	private bool blocked = false;
	private bool highlighted = false;

	public bool Blocked {
		get { return blocked; }
		set { 
			blocked = value;
			highlighted = false;
			if (cellRenderer == null)
				return;
			Color clr = blocked ? Color.red : Color.white;
			clr.a = cellRenderer.color.a;
			cellRenderer.color = clr;
		}
	}

	public bool Highlighted {
		get { return highlighted; }
		set { 
			if (blocked)
				return;
			highlighted = value;
			if (cellRenderer == null)
				return;
			Color clr = highlighted ? Color.green : Color.white;
			clr.a = cellRenderer.color.a;
			cellRenderer.color = clr;
		}
	}

	private SpriteRenderer cellRenderer;
	// Use this for initialization
	void Start () {
		cellRenderer = transform.GetChild (0).GetComponent<SpriteRenderer> ();
		Blocked = blocked;
		Highlighted = highlighted;
	}

}
