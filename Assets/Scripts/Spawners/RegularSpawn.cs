/*
	Generate a new object at regular intervals

	Gilberto Echeverria
	12/04/2020
*/
using System.Collections;
using UnityEngine;

public class RegularSpawn : MonoBehaviour {

	[SerializeField] Transform parentObject;
	[SerializeField] GameObject enemyPrefab;
	[SerializeField] float minDelay = 0.5f;
	[SerializeField] float maxDelay = 3.0f;

	// Use this for initialization
	void Start () {
		StartCoroutine(RandomSpawner());
	}
	
	IEnumerator RandomSpawner()
    {
    	while(true)
    	{
    		// Wait a random time
    		yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

	        // Get a random starting location
			Vector3 startPosition = new Vector3(Random.Range(-8f, 8f), 20, 0);
			GameObject obj = Instantiate(enemyPrefab, startPosition, Quaternion.identity);
			obj.transform.parent = parentObject;
	    }
    }
}
