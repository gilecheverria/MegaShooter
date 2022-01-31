/*
Script to change the intensity of the light during time

Gilberto Echeverria
24/04/2018
*/
using UnityEngine;

public class LightDimmer : MonoBehaviour {
    public float duration = 1.0f;
    public float intensity = 0.3f;
    public float minimum = 0.5f;

    Light lt;

    void Start() {
        lt = GetComponent<Light>();
    }

    void Update() {
        // Use the cosine function to cycle the light intensity
        float phi = Time.time / duration * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * intensity + minimum;
        lt.intensity = amplitude;
    }
}
