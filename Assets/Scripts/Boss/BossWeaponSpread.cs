/*
Script to control the guns on the boss ship

Gilberto Echeverria
2022-12-22
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeaponSpread : MonoBehaviour
{
    [SerializeField] float initialDelay;
    [SerializeField] float waveDelay;
    [SerializeField] float minAngle;
    [SerializeField] float maxAngle;
    [SerializeField] float angleDelta;
    [SerializeField] float shotDelay;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform spawnerParent;

    float nextFire;
    float shotAngle;
    Transform bulletParent;

    // Start is called before the first frame update
    void Start()
    {
        // Wait before firing the first shot
        nextFire = Time.time + initialDelay;

        // Get the empty that will be parent to all bullets
        bulletParent = GameObject.Find("BulletParent").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Fire the cannon with a delay between shots
        if (Time.time > nextFire) {
            StartCoroutine(FireGun());
        }
    }

    // Reset the fire counters when the script is re-enabled
    void OnEnable()
    {
        nextFire = Time.time + initialDelay;
    }

	// Fire a series of bullets after a delay
	IEnumerator FireGun ()
    {
        // Set the time for the next shot
        nextFire = Time.time + waveDelay;
        // Initialize the angle
        shotAngle = minAngle;
        while (shotAngle <= maxAngle) {
            foreach (Transform empty in spawnerParent) {
                // Compute the angle for the new prefab
                Vector3 spawnRot = empty.localRotation.eulerAngles;
                Quaternion rotation = Quaternion.Euler(spawnRot.x,
                                                       spawnRot.y,
                                                       spawnRot.z + shotAngle);
                // Create the bullet in the correct rotation
                GameObject bullet = Instantiate(bulletPrefab,
                                                empty.position,
                                                rotation);
                bullet.transform.parent = bulletParent;
            }
            yield return new WaitForSeconds(shotDelay);
            shotAngle += angleDelta;
        }
    }
}
