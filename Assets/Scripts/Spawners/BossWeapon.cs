/*
Script to control the guns on the boss ship

Gilberto Echeverria
2022-12-22
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    [SerializeField] float fireDelay;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform spawnerParent;

    float nextFire;
    Transform bulletParent;

    // Start is called before the first frame update
    void Start()
    {
        // Wait before firing the first shot
        nextFire = 6.0f;

        // Get the empty that will be parent to all bullets
        bulletParent = GameObject.Find("BulletParent").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Fire the cannon with a delay between shots
        if (Time.time > nextFire) {
            FireGun();
        }
    }

	// Create a new bullet
	void FireGun ()
    {
        foreach (Transform empty in spawnerParent) {
            // Starting position and orientation of the bullet depends on
            // the empties attached to the ship
            GameObject bullet = Instantiate(bulletPrefab,
                                            empty.position,
                                            empty.localRotation);
            bullet.transform.parent = bulletParent;
        }
        // Set the time for the next shot
        nextFire = Time.time + fireDelay;
    }
}
