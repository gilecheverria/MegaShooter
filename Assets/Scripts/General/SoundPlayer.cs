using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour {

	public AudioClip nextClip;

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space))
		{
			GetComponent<AudioSource>().Play();
		}
		if (Input.GetKey(KeyCode.S))
		{
			GetComponent<AudioSource>().clip = nextClip;
			GetComponent<AudioSource>().Play();
		}
	}

	public void Play ()
	{
		GetComponent<AudioSource>().Play();
	}
}
