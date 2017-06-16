using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathContact : MonoBehaviour {

	public GameManager gm;

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player") {
			Debug.Log("Following");
			if(gm == null)
				gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

			gm.EndGame();
		}
	}
}
