/*
    Move the attached object in a direction specified,
    while also moving horizontally back and forth

    Gilberto Echeverria
    13/04/2020
*/

using UnityEngine;

public class SineMovement : MonoBehaviour {

    [SerializeField] float rotationMultiplier = 15;
    [SerializeField] bool fixDirection;

	public Vector3 motion;
    public float duration = 1.0f;
    public float width = 1.0f;

    float direction;

    void Start ()
    {
    	// Use a multiplier to determine the amplitude of the horizontal movement
        if (fixDirection)
    	    direction = 0.9f;
        else
    	    direction = Random.Range(-1f, 1f);
    }
	
	// Update is called once per frame
	void Update ()
    {
		// Compute a sinusoidal movement for the x coordinate
		float phi = Time.time / duration * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * width * direction;
        motion.x = amplitude;

        // Rotate the ship as it moves side to side
		Vector3 localRotation = transform.localEulerAngles;
		localRotation.y = -motion.x * rotationMultiplier;
		transform.localEulerAngles = localRotation;

        transform.Translate(motion * Time.deltaTime, null);
	}
}
