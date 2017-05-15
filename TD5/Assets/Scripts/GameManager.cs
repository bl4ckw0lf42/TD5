using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public int startingLives = 100;

	private int lives;
	private int money;

	// Use this for initialization
	void Start () {
		lives = startingLives;
	}

	public int GetLives() {
		return lives;
	}

	public int GetMoney() {
		return money;
	}

	public void RemoveLives(int lives) {
		this.lives -= lives;
	}

	public void AddMoney(int money) {
		this.money += money;
	}

	public void RemoveMoney(int money) {
		this.money -= money;
	}
}
