/*
Demo simulation of gravity between objects.
From the video at:
https://www.youtube.com/watch?v=Ouu3D_VHx9o

Gilberto Echeverria
2021-03-12
*/

using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public Rigidbody rb;

    const float G = 667.4f;

    public static List<Attractor> attractors;

    void OnEnable()
    {
        // Initialize the list
        if (attractors == null)
            attractors = new List<Attractor>();
        attractors.Add(this);
    }

    void OnDisable()
    {
        attractors.Remove(this);
    }

    void FixedUpdate()
    {
        foreach (Attractor attractor in attractors) {
            if (attractor != this) {
                Attract(attractor);
            }
        }
    }

    void Attract(Attractor objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.GetComponent<Rigidbody>();
        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;
        if (distance != 0) {
            float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
            Vector3 force = forceMagnitude * direction.normalized;
            rbToAttract.AddForce(force);
        }
    }
}
