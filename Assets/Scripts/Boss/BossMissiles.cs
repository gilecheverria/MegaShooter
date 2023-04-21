/*
Shoot seeker missiles at the player ship

Gilberto Echeverria
2023-04-10
*/

using UnityEngine;

public class BossMissiles : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform spawnerParent;

    Transform bulletParent;

    // Start is called before the first frame update
    void Start()
    {
        // Get the empty that will be parent to all bullets
        bulletParent = GameObject.Find("BulletParent").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        FireMissiles();
    }

    void FireMissiles()
    {
        foreach (Transform empty in spawnerParent) {
            // Compute the angle for the new prefab
            Vector3 spawnRot = empty.localRotation.eulerAngles;
            Quaternion rotation = Quaternion.Euler(spawnRot.x,
                                                    spawnRot.y,
                                                    spawnRot.z);
            // Create the bullet in the correct rotation
            GameObject bullet = Instantiate(bulletPrefab,
                                            empty.position,
                                            rotation);
            bullet.transform.parent = bulletParent;
        }
    }
}
