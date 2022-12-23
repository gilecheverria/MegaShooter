/*
Set a timer to go to the boss scene

Gilberto Echeverria
2022-12-22
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToBoss : MonoBehaviour
{
    [SerializeField] float secondsToBoss;
    [SerializeField] MonoBehaviour[] spawners;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SwitchBossScene", secondsToBoss);
    }

    void SwitchBossScene()
    {
        // Disable spawner scripts
        foreach (MonoBehaviour script in spawners) {
            script.enabled = false;
        }

        SceneManager.LoadSceneAsync("Boss");
    }
}
