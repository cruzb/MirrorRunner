﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathContact : MonoBehaviour {

	public GameManager gm;
	
	void Start () {
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Enemy") {
			gm.EndGame();
		}
	}
}
