using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public int startingLives = 100;
	public int staringMoney = 100;

	private int lives;
	private int money;

	// Use this for initialization
	void Start () {
		lives = startingLives;
		money = staringMoney;
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			GameObject.Find ("Level Manager").GetComponent<LevelManager> ().LoadLevel("Main Menu");
		}
	}

	public int GetLives() {
		return lives;
	}

	public int GetMoney() {
		return money;
	}

	public void RemoveLives(int lives) {
		this.lives -= lives;
		if (this.lives <= 0) {
			GameObject.Find ("Level Manager").GetComponent<LevelManager> ().GameOver ();
		}
	}

	public void AddMoney(int money) {
		this.money += money;
	}

	public void RemoveMoney(int money) {
		this.money -= money;
	}
}
