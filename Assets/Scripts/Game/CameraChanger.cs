/*
    Change the camera used during the game, when pressing certain buttons

    Gilberto Echeverria
    12/04/2020
*/

using UnityEngine;

public class CameraChanger : MonoBehaviour {
    public GameObject topCamera;
    public GameObject angledCamera;

    bool angledActive = true;

    // Use this for initialization
    void Start () {
        // Get the currently selected camera from the preferences
        angledActive = PlayerPrefs.GetInt("Angled Camera") == 1;
        // Activate the corresponding camera
        ActivateSelectedCamera();
    }
    
    // Update is called once per frame
    void Update () {
        // Toggle the camera selected with some buttons
        if (Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.C))
        {
            angledActive = !angledActive;
            ActivateSelectedCamera();
        }
    }

    // Enable the selected camera, and disable the other one
    void ActivateSelectedCamera() {
        if (angledActive)
        {
            angledCamera.SetActive(true);
            topCamera.SetActive(false);
        }
        else
        {
            topCamera.SetActive(true);
            angledCamera.SetActive(false);
        }
    }
}
