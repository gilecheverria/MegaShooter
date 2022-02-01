/*
	Generate a new obstacle object at one of several fixed positions

	Gilberto Echeverria
	2022-02-01
*/
using System.Collections;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour {

	[SerializeField] Transform parentObject;
	[SerializeField] GameObject obstaclePrefab;
	[SerializeField] float minDelay = 5f;
	[SerializeField] float maxDelay = 5f;

	[SerializeField] float separation = 4.5f;
	[SerializeField] int limit = 3;

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
			Vector3 startPosition = new Vector3(Random.Range(-limit, limit) * separation, 10, 100);
			GameObject obstacle = Instantiate(obstaclePrefab, startPosition,
											  Quaternion.Euler(90, 0, 0));
			obstacle.transform.parent = parentObject;
			Destroy(obstacle, 20.0f);
	    }
    }
}
