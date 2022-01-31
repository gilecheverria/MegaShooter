/*
	Keep track of the current value for the game's High Score

	Gilberto Echeverria
	12/04/2020
*/

using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	public Text highScoreText;

	// Use this for initialization
	void Start () {
		// Get the previously stored High Score
		ScoreManager.highScore = PlayerPrefs.GetInt("High Score");
		// Change the text to reflect the score
		highScoreText.text = ScoreManager.highScore.ToString();
	}

	public void ResetHighScore() {
		ScoreManager.ResetHighScore();
		// Change the text to reflect the score
		highScoreText.text = ScoreManager.highScore.ToString();
	}
	
}
