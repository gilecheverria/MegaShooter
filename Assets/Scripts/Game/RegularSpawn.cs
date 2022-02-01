/*
	Generate a new object at regular intervals

	Gilberto Echeverria
	12/04/2020
*/
using System.Collections;
using UnityEngine;

public class RegularSpawn : MonoBehaviour {

	public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
		StartCoroutine(RandomSpawner());
	}
	
	IEnumerator RandomSpawner()
    {
    	while(true)
    	{
    		// Wait a random time
    		yield return new WaitForSeconds(Random.Range(0.5f, 3f));

	        // Get a random starting location
			Vector3 startPosition = new Vector3(Random.Range(-8f, 8f), 20, 0);
			Instantiate(enemyPrefab, startPosition, Quaternion.identity);
	    }
    }
}
