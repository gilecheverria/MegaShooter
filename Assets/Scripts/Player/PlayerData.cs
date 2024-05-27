/*
Script with a reference to a Scriptable Object with the data for the player

Gilberto Echeverria
2024-05-27
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public PlayerStatusSO playerStatus;

    public void Init()
    {
        playerStatus.level = 1;
        playerStatus.score = 0;
        playerStatus.lives = 5;
    }
}
