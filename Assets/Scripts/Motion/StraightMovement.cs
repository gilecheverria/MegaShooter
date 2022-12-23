/*
Enemies moving in a straight line
The direction can be set in the Unity interface, 
or decided randomly when the object is intantiated

Gilberto Echeverria
2021-04-27
*/

using UnityEngine;

public class StraightMovement : MonoBehaviour {

	public bool random;
	public Vector3 motion;
	public float speed;

	// Use this for initialization
	void Start () {
        // Figure out a random direction
		if (random)
		{
        	motion = new Vector3(Random.Range(-3f, 3f), -6, 0);
		} else if (speed != 0) {
			motion = Vector3.up * speed;
		}
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(motion * Time.deltaTime);
    }
}
