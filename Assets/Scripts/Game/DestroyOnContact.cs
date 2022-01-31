/*
    Destroy any object that comes in contact with the
    object that has this script

    Gilberto Echeverria
    10/04/2020
*/

using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy" || col.tag == "PowerUp")
        {
            Destroy(col.gameObject);
        }
    }
}
