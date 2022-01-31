using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPowerUp : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            PlayerWeapon pw = col.GetComponent<PlayerWeapon>();
            pw.IncreaseLevel();
            Destroy(gameObject);
        }
    }
}
