/*
Change the text in the version label in the title screen

Gilberto Echeverria
2023-04-20
*/

using UnityEngine;
using UnityEngine.UI;

public class Version : MonoBehaviour
{
    [SerializeField] Text versionText;
    [SerializeField] string date;

    // Start is called before the first frame update
    void Start()
    {
        versionText.text = "Version: " + date;
    }
}