using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public float levelSpeed;
	public bool topActive;

	public List<Transform> blocks;

	void Start () {
		topActive = true;
	}
	
	void Update () {
		//Debug.Log(blocks.Count);
		if (Input.GetMouseButtonDown(0)) {
			if (Input.mousePosition.x > Screen.width / 2) {
				topActive = !topActive;
				for(int i = 0; i < blocks.Count; i++) {
					for (int j = 0; j < blocks[i].childCount; j++) {
						Debug.Log( blocks[i].name);
						blocks[i].GetChild(j).GetComponent<BlockSwitch>().Switch();
					}
				}
			}
		}
	}

	public void EndGame() {

	}
	
	public void RestartGame() {

	}

	public void QuitGame() {

	}
}
