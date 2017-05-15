using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiUpdater : MonoBehaviour {

	private Text livesDisplay;
	private Text moneyDisplay;
	private Text detailsText;

	private GameObject detailsObject;
	private GameManager gm;

	private string towerDetailsTemplate = 
		"Price:    {0}\n" +
		"Damage:   {1}\n" +
		"Firerate: {2}\n" +
		"Range:    {3}";

	// Use this for initialization
	void Start () {
		gm = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager> ();
		livesDisplay = GameObject.Find ("LivesDisplay").GetComponent<Text> ();
		moneyDisplay = GameObject.Find ("MoneyDisplay").GetComponent<Text> ();
		detailsText = GameObject.Find ("DetailsText").GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {
		UpdateInfoPanel ();

		UpdateDetailsPanel ();

		/*if (Input.GetMouseButtonDown (0)) {
			detailsObject = null;
		}*/
	}

	void UpdateInfoPanel() {

		livesDisplay.text = gm.GetLives ().ToString ();
		moneyDisplay.text = gm.GetMoney ().ToString ();
	}

	void UpdateDetailsPanel() {
		if (detailsObject == null) {
			detailsText.text = string.Empty;
		} else if (detailsObject.GetComponent<Tower> () != null) {
			Tower t = detailsObject.GetComponent<Tower> ();
			detailsText.text = string.Format (towerDetailsTemplate, t.price, t.damage, t.fireRate, t.range);

		} else if (detailsObject.GetComponent<Enemy> () != null) {
			Enemy e = detailsObject.GetComponent<Enemy> ();
		}
	}

	public void SetDetailsObject(GameObject go) {
		detailsObject = go;
	}
}
