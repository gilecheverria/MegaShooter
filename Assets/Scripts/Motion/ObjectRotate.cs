using UnityEngine;
using System.Collections;

public class ObjectRotate : MonoBehaviour {

	public Vector3 rotationAngles;
    public float speed;

	// Update is called once per frame
	void Update () {
		transform.Rotate (rotationAngles * speed * Time.deltaTime);
	}
}
