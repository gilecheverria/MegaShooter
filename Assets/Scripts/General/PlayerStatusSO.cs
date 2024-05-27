/*
Scriptable Objecto to hold persistent data about the player through a run

Gilberto Echeverria
2024-05-27
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData",
                 menuName = "ScriptableObjects/PlayerStatusSO",
                 order = 1)]
public class PlayerStatusSO : ScriptableObject
{
    public int score;
    public int level;
    public int lives;
}
