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

	public Text gameScoreText;
	public Text highScoreText;

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
		scoreText.text = score.ToString("00000000");
	}

	public void PassPlatform() {
		AddScore(scorePerPlatform);
	}

	public void HandleHighScore() {
		gameScoreText.text = score.ToString("00000000");

		int highScore = PlayerPrefs.GetInt("highscore");
		if(score > highScore) {
			highScoreText.text = score.ToString("00000000");
			PlayerPrefs.SetInt("highscore", score);
		}
		else {
			if (score > PlayerPrefs.GetInt("highscore1"))
				PlayerPrefs.SetInt("highscore1", score);
			else if (score > PlayerPrefs.GetInt("highscore2"))
				PlayerPrefs.SetInt("highscore2", score);
			else if (score > PlayerPrefs.GetInt("highscore3"))
				PlayerPrefs.SetInt("highscore3", score);
			else if (score > PlayerPrefs.GetInt("highscore4"))
				PlayerPrefs.SetInt("highscore4", score);


			highScoreText.text = highScore.ToString("00000000");
		}

	}
}
