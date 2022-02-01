/*
    Update the values in the GUI during the game

    Gilberto Echeverria
    12/04/2020
*/

using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    public Text scoreText;
    public Text gameOverText;
    public Text hiScoreText;
    public Text levelText;
    public Image pauseImage;

    Image subimage;

    bool paused = false;
 
    // Use this for initialization
    void Start () {
        // Get a reference to the image for the pause overlay
        subimage = pauseImage.GetComponent<Image>();
        UpdateHighScore();
    }

    // Update is called once per frame
    void Update () {
        scoreText.text = ScoreManager.score.ToString();

        // Detect the pressing of the ESC key
        if (Input.GetButtonDown("Pause")) {
            PauseGame();
        }
    }

    // Switch the variable to indicate when the game is finished
    public void GameOver () {
        gameOverText.enabled = true;
    }

    // Method to pause/resume the game
    public void PauseGame() {
        if (paused) {
            // Resume the game
            Time.timeScale = 1.0f;
            // Hide the gray overlay
            subimage.enabled = false;
            // Change the text of the button
            //textPause.text = "Pause";
        } else {
            // Stop the game
            Time.timeScale = 0.0f;
            // Show the gray overlay
            subimage.enabled = true;
            // Change the text of the button
            //textPause.text = "Resume";
        }
        // Toggle the paused value
        paused = !paused;
    }

    // Method to determine if the game is paused
    public bool IsPaused() {
        return paused;
    }

    public void UpdateLevel(int level) {
        levelText.text = level.ToString();
    }

    public void UpdateScore(int score) {
        scoreText.text = score.ToString();
    }

    public void UpdateHighScore() {
        hiScoreText.text = PlayerPrefs.GetInt("High Score").ToString();
    }
}
