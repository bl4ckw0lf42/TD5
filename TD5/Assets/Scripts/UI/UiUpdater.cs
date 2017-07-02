using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiUpdater : MonoBehaviour {

	private Text livesDisplay;
	private Text moneyDisplay;
	private Text detailsText;
	private TowerPanel towerPanel;
	private Text countdown;

	private GameObject detailsObject;
	private GameManager gm;
	private WaveGenerator waveGenerator;


	private string towerDetailsTemplate = 
		"Name:     {0}\n" +
		"Price:    {1}\n" +
		"Damage:   {2}\n" +
		"Firerate: {3}\n" +
		"Range:    {4}";

	// Use this for initialization
	void Start () {
		gm = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager> ();
		livesDisplay = GameObject.Find ("LivesDisplay").GetComponent<Text> ();
		moneyDisplay = GameObject.Find ("MoneyDisplay").GetComponent<Text> ();
		detailsText = GameObject.Find ("DetailsText").GetComponent<Text> ();
		countdown = GameObject.Find ("Countdown").GetComponent<Text> ();
		towerPanel = GameObject.Find ("TowerPanel").GetComponent<TowerPanel> ();
		waveGenerator = GameObject.Find ("WaveGenerator").GetComponent<WaveGenerator> ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateInfoPanel ();

		UpdateDetailsPanel ();

		UpdateTowerPanel ();


		updateTimePanel ();
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
			detailsText.text = string.Format (towerDetailsTemplate, t.name, t.price, t.damage, t.fireRate, t.range);

		} else if (detailsObject.GetComponent<Enemy> () != null) {
			Enemy e = detailsObject.GetComponent<Enemy> ();
		}
	}

	void updateTimePanel() {
		if (waveGenerator.areWavesLeft) {
			countdown.text = waveGenerator.GetSecondsTilNextWave ().ToString ();
		} else {
			countdown.text = "-";
		}

	}

	void UpdateTowerPanel() {
		towerPanel.UpdateTowerPlaceholders (gm.GetMoney ());
	}

	public void SetDetailsObject(GameObject go) {
		detailsObject = go;
	}
}
