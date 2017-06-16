using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundContact : MonoBehaviour {

	public GameManager gm;

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.name == "TopPlayer") {
			if (gm == null)
				gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

			gm.EndGame();
		}
	}
}
