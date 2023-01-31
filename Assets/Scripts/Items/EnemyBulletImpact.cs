/*
Deal damage to the player

Gilberto Echeverria
2022-12-22
*/

using UnityEngine;

public class EnemyBulletImpact : MonoBehaviour {
	[SerializeField] GameObject explosionPrefab;
    [SerializeField] GameObject impactPrefab;
    //[SerializeField] int damage = 1;    // Default value

	// Detect collisions with enemies
	void OnTriggerEnter (Collider col)
    {
        if(col.tag == "Player") {
            /*
            Health health = col.GetComponent<Health>();
            if (health) {
                health.TakeDamage(damage);
            }

            // Create a particle explosion
            GameObject explosion = Instantiate(explosionPrefab, col.gameObject.transform.position, Quaternion.identity);
            // Destroy the explosion object
            Object.Destroy(explosion, 1.0f);
            */

            // Destroy the bullet with a small explosion
            Impact();
        }
        if(col.tag == "Obstacle") {
            // Destroy the bullet with a small explosion
            Impact();
        }
        if(col.tag == "Destroyer") {
            // Just get rid of instances outside the playing field
            Destroy(gameObject);
        }
    }

    void Impact ()
    {
        // Create the particle impact
        GameObject impact = Instantiate(impactPrefab, transform.position, Quaternion.identity) as GameObject;
        // Destroy the explosion object
        Object.Destroy(impact, 1.0f);
        // Destroy the bullet
        Destroy(gameObject);
    }
}