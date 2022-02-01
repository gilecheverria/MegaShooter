/*
	Main script to control the ship motion
    and detect collisions with enemies or obstacles

	Gilberto Echeverria
	31/01/2022		Fix code formatting
	11/03/2020		Added weapon power up
	13/04/2020		Moved weapon code to another script
                    Added vertical movement
*/

using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public GameObject explosionPrefab;
	public float motionSpeed = 10;
	public float borderDistance = 9;
    public float topBorder = 7;
    public float bottomBorder = -5;
	public float rotationMultiplier = 15;

	Collider shipCollider;
	GameObject shieldObject;
    Vector3 motion;

	// Use this for initialization
	void Start () {
		// Get a reference to the collider
		shipCollider = GetComponent<Collider>();
		// Disable collisions at first
		shipCollider.enabled = false;
		// Start the timer to activate collisions after a second
		StartCoroutine(ActivateCollisions());
		// Get a reference to the shield
		shieldObject = transform.Find("Shield").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		// Get the user input
		motion.x = Input.GetAxisRaw("Horizontal");
		motion.y = Input.GetAxisRaw("Vertical");

        // Use mouse input if the keyboard is not being pressed
        if (motion.x == 0) {
            motion.x = Input.GetAxis("Mouse X");
        }
        if (motion.y == 0) {
            motion.y = Input.GetAxis("Mouse Y");
        }

		// Rotate the ship when the ship moves to the sides
		Vector3 localRotation = transform.localEulerAngles;
		localRotation.y = -motion.x * rotationMultiplier;
		transform.localEulerAngles = localRotation;
		
		// Limit the movement according to the bounds of the scene
		if ( (transform.position.x > borderDistance && motion.x > 0) ||
			 (transform.position.x < -borderDistance && motion.x < 0) ) {
            motion.x = 0;
        }
		if ( (transform.position.y > topBorder && motion.y > 0) ||
			 (transform.position.y < bottomBorder && motion.y < 0) ) {
            motion.y = 0;
        }

        // Apply the motion to the ship
        transform.Translate(motionSpeed * motion * Time.deltaTime, null);
    }

	// Detect collisions with enemies
	void OnTriggerEnter (Collider col)
    {
        if(col.tag == "Enemy") {
			KillPlayer();
			// Destroy the enemy
            Destroy(col.gameObject);
        }
        if(col.tag == "Obstacle") {
        	KillPlayer();
        }
    }

	void KillPlayer()
	{
		// Create an instance of the particle system
		GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		// Destroy the particles after some time
		Object.Destroy(explosion, 2.0f);
		// Destroy the player ship
		Destroy(gameObject);	
	}

	// Give players some time before the collider is active
	IEnumerator ActivateCollisions()
	{
		yield return new WaitForSeconds(1.0f);
		shipCollider.enabled = true;
		Object.Destroy(shieldObject);
	}
}
