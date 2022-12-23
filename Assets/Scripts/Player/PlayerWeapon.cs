/*
 * Allow the player ship to fire projectiles
 * Uses a leveling system to allow for more projectiles when powering up
 *
 * Gilberto Echeverria
 * 18/09/2020
 * 01/01/2022       Allow power-up beyong level 3
 *                  Making the laser shoot faster
 * 22/12/2022       Instantiate bullets with the same orientation as the empty
 */

using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
	[SerializeField] GameObject bulletPrefab;
	[SerializeField] Transform[] shotSpawns;
	[SerializeField] float fireDelay;
	[SerializeField] int weaponLevel;

    List<int> spawnIndices;
    float nextFire;
    GUIManager guiManager;
    AudioSource audioSource;
    Transform bulletParent;

    // Start is called before the first frame update
    void Start()
    {
        // Prepare to fire the next shot
        nextFire = 0.0f;
        // Get a reference to the script that modifies the GUI texts
        guiManager = GameObject.FindWithTag("GameController").GetComponent<GUIManager>();
        // Initialize the list of spawners
        spawnIndices = new List<int>();
        spawnIndices.Add(0);
        // Reset the display for the level of the ship
        guiManager.UpdateLevel(weaponLevel);
        // Get the source for the power up sound
        audioSource = GetComponent<AudioSource>();
        // Get the empty that will be parent to all bullets
        bulletParent = GameObject.Find("BulletParent").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Fire the cannon with a delay between shots
        if (Input.GetButton("Fire1") && Time.time > nextFire) {
            FireGun();
        }
    }

	// Create a new bullet
	void FireGun ()
    {
        foreach (int index in spawnIndices) {
            // Starting position and orientation of the bullet depends on
            // the empties attached to the ship
            GameObject bullet = Instantiate(bulletPrefab,
                                            shotSpawns[index].position,
                                            shotSpawns[index].localRotation);
            bullet.transform.parent = bulletParent;
        }
        // Set the time for the next shot
        nextFire = Time.time + fireDelay;
    }

    // Increase the power on the ship lasers
    public void IncreaseLevel()
    {
        weaponLevel++;
        guiManager.UpdateLevel(weaponLevel);
        audioSource.Play();

        switch(weaponLevel) {
            case 2:
                spawnIndices.Remove(0);
                spawnIndices.Add(1);
                spawnIndices.Add(2);
                break;
            case 3:
                spawnIndices.Add(0);
                break;
            // Levels higher than 3
            default:
                // Make the fire rate faster
                if (fireDelay > 0) {
                    fireDelay -= 0.02f * (weaponLevel - 3);
                }
                break;
        }
    }
}
