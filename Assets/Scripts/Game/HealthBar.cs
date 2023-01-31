/*
Script to update the health of a character as a slider bar

Gilberto Echeverria
2023-01-30
*/

using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider bar;

    public void Init(int maxHP)
    {
        bar.maxValue = maxHP;
        bar.value = maxHP;
    }

    public void SetValue(int value)
    {
        bar.value = value;
    }
}