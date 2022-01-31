using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleCameraOption : MonoBehaviour {

    public Toggle cameraToggle;

    void Start () {

        // Set the state of the toggle to the current value stored
        cameraToggle.isOn = PlayerPrefs.GetInt("Angled Camera") == 1;

        // Add a new event listener to detect changes to the toggle
        // Code based on:
        // https://stackoverflow.com/questions/31635739/how-to-use-unity-toggle-check-function-checked-and-unchecked
        cameraToggle.onValueChanged.AddListener( (value) =>
            {
                ToggleCamera(value);
            });
    }

    // Set a preference variable to store the camera selected
    public void ToggleCamera (bool angledCamera) {
        if (angledCamera)
        {
            //print("New view is ANGLED");
            PlayerPrefs.SetInt("Angled Camera", 1); 
        }
        else
        {
            //print("New view is TOP");
            PlayerPrefs.SetInt("Angled Camera", 0); 
        }
    }
}
