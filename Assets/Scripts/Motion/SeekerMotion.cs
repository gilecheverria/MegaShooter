/*
Script for rockets that follow the player ship

Gilberto Echeverria
2023-04-08
*/

using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class SeekerMotion : MonoBehaviour
{
    [SerializeField] float speed;

    Transform target;
    Rigidbody rb;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If the target was lost (destroyed) look for another instance
        if (!target) {
            GameObject player = GameObject.FindWithTag("Player");
            // Get the transform for the new player ship
            if (player) {
                target = player.transform;
            }
        } else {
            transform.LookAt(target.position);
            rb.velocity = transform.forward * speed;
        }
    }
}