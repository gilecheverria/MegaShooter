/*
Script on the Power-Up's, to increase the level of the players weapon

Gilberto Echeverria
2022-01-31
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPowerUp : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            PlayerWeapon pw = collider.GetComponent<PlayerWeapon>();
            pw.IncreaseLevel();
            Destroy(gameObject);
        }
    }
}
