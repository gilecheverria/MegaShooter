/*
Add an initial force to the object when the scene starts

Gilberto Echeverria
2021-03-24
*/

using UnityEngine;

public class PlanetMotion : MonoBehaviour
{
    [SerializeField] float force;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force);
    }
}
