using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour {
	public int lives = 5;
	public GameObject playerPrefab;
	public Image[] livesIcons;
	public GameObject livesLayout;
	public Image lifeIcon;

	GUIManager guiScript;
	GameObject playerObject;
	bool respawningPlayer = false;
	Vector3 startPosition;

	// Initialize references when the scene starts
	void Awake () {
		guiScript = GetComponent<GUIManager>();
	}

	// Use this for initialization
	void Start () {
		// Set the initial score for this game to 0
		ScoreManager.score = 0;

		startPosition = new Vector3(0, -3.5f, 0);
		// Prepare the display of the lives
		//InitLivesUI();
		// Create the first player ship
		SpawnPlayer();
	}

	// Update is called once per frame
	void Update () {
		if (playerObject == null && respawningPlayer == false)
		{
			StartCoroutine(RespawnPlayer());
		}
	}

	// Currently unused function
	// Used to dynamically initialize an array of images
	void InitLivesUI()
	{
		Image tmpImage;

		for (int i=0; i<lives; i++)
		{
			tmpImage = Instantiate(lifeIcon) as Image;
			tmpImage.name = "life" + i.ToString();
			tmpImage.transform.SetParent(livesLayout.transform);
		}
	}

	public void SpawnPlayer()
	{
		if (lives > 0)
		{
			// Create new player
			playerObject = Instantiate(playerPrefab, startPosition, Quaternion.identity) as GameObject;
			lives--;
			// Hide one of the existing image objects
			livesIcons[lives].enabled = false;
			// Destroy dynamically created life icons
			//GameObject tmpImage = GameObject.Find("life"+lives.ToString());
			//tmpImage.SetActive(false);
		}
		else
		{
			// Check if the game score is the highest
			ScoreManager.SetHighScore();
			// Finish the game and return to the menu screen
			guiScript.GameOver();
			StartCoroutine(ReturnToMenu());
		}
	}

	IEnumerator RespawnPlayer()
	{
		respawningPlayer = true;
		yield return new WaitForSeconds(2);
		SpawnPlayer();
		respawningPlayer = false;
	}

	IEnumerator ReturnToMenu()
	{
		yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Intro");
    }
}
