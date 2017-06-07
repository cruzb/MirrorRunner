using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeath : MonoBehaviour {

	public GameManager gameManager;

	void Start() {
		if(gameManager == null) {
			gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		}	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Enemy") {
			gameManager.EndGame();
		}
	}
}
