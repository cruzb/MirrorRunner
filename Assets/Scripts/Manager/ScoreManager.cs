using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public int scoreRate;
	public int scorePerPlatform;

	private int score;
	private float lastTimeScoreAdded;

	void Start () {
		score = 0;
		lastTimeScoreAdded = Time.time;
	}
	
	void Update () {
		if(Time.time >= lastTimeScoreAdded + 1f) {
			lastTimeScoreAdded = Time.time;
			AddScore(scoreRate);
		}
	}


	public int GetScore() {
		return score;
	}

	public void AddScore(int s) {
		score += s;
		scoreText.text = score.ToString("00000000000");
	}

	public void PassPlatform() {
		AddScore(scorePerPlatform);
	}
}
