﻿/*
 * Allow the player ship to fire projectiles
 * Uses a leveling system to allow for more projectiles when powering up
 *
 * Gilberto Echeverria
 * 18/09/2020
 * 01/01/2022       Allow power-up beyong level 3
 *                  Making the laser shoot faster
 */

using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
	public GameObject bulletPrefab;
	public Transform[] shotSpawns;
	public float fireDelay;
	public int weaponLevel;

    List<int> spawnIndices;
    float nextFire;
    GUIManager guiManager;
    AudioSource audioSource;

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
            // Starting position of the bullet depends on the position of the ship
            Instantiate(bulletPrefab, shotSpawns[index].position, Quaternion.identity);
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
