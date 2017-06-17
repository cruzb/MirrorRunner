using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public ScoreManager sm;
	public Text scoreText;

	public float levelSpeed;
	public bool topActive;

	public List<Transform> blocks;

	public ToggleCanvas tc;

	void Start () {
		topActive = true;
	}
	
	void Update () {
		//Debug.Log(blocks.Count);
		if (Input.GetMouseButtonDown(0)) {
			if (Input.mousePosition.x > Screen.width / 2) {
				topActive = !topActive;
				for (int i = 0; i < blocks.Count; i++) {
					if (blocks[i]) { 
						for (int j = 0; j < blocks[i].childCount; j++) {
							//Debug.Log(blocks[i].name);
							blocks[i].GetChild(j).GetComponent<BlockSwitch>().Switch();
						}
					}
				}
			}
		}
	}

	public void Remove() {
		while (blocks[0] == null)
			blocks.RemoveAt(0);
	}

	public void EndGame() {
		tc.Toggle();
		Time.timeScale = 0;
		sm.HandleHighScore();
	}
	
	public void RestartGame() {
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void QuitGame() {
		//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		//load menu scene
	}
}
