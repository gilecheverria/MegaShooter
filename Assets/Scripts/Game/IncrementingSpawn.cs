/*
	Create objects at an increasing rate

	Gilberto Echeverria
	12/04/2020
*/

using UnityEngine;

public class IncrementingSpawn : MonoBehaviour {

	public float spawnRate;
	public GameObject enemyPrefab;

	float lastSpawn;

	// Use this for initialization
	void Start () {
		lastSpawn = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(lastSpawn + spawnRate < Time.time)
		{
            Spawn(enemyPrefab);

			// Store the time of the last enemy created
			lastSpawn = Time.time;
		}
		
		// Create more enemies the longer the user plays
		if (spawnRate > 0.1)
			spawnRate -= 0.01f * Time.deltaTime;
	}

    // Method that creates the actual enemy object
    void Spawn(GameObject prefab)
    {
        // Get a random starting location
        Vector3 startPosition = new Vector3(Random.Range(-8f, 8f), 20, 0);
        Instantiate(prefab, startPosition, Quaternion.identity);
    }
}
