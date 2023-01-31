/*
Scriptable object to keep the list of songs to be played in each stage

This will be attached to the music objects in each scene

Gilberto Echeverria
2023-01-31
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data",
                 menuName = "ScriptableObjects/MusicListSO",
                 order = 1)]
public class MusicListSO : ScriptableObject
{
    // Array of audio files
    public AudioClip[] samples;
    // Array of scene names where the music is played
    public string[] scenes;
}
