/*
Hold the score and high score.
Update when necessary

Gilberto Echeverria
2021-04-27
*/

using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public static int score;
	public static int highScore;

	public static void SetHighScore() {
		if (score > highScore)
		{
			highScore = score;
			// Store the score permanently
			PlayerPrefs.SetInt("High Score", highScore);
		}
	}

	public static void ResetHighScore() {
		highScore = 0;
		PlayerPrefs.SetInt("High Score", 0);
	}

}
