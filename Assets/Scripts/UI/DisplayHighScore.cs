using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour {

	public Text hs0, hs1, hs2, hs3, hs4;

	public void Display() {
		hs0.text = PlayerPrefs.GetInt("highscore").ToString("00000000");
		hs1.text = PlayerPrefs.GetInt("highscore1").ToString("00000000");
		hs2.text = PlayerPrefs.GetInt("highscore2").ToString("00000000");
		hs3.text = PlayerPrefs.GetInt("highscore3").ToString("00000000");
		hs4.text = PlayerPrefs.GetInt("highscore4").ToString("00000000");
	}
}
