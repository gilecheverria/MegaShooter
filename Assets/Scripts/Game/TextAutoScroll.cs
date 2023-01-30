/*
Animate text to scroll so all of it can be seen in a single screen
Based on the video at:
https://www.youtube.com/watch?v=9a6GyAbhLUk

Gilberto Echeverria
2023-01-30
*/

using UnityEngine;
using System.Collections;

public class TextAutoScroll : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float finalHeight;
    [SerializeField] bool loop;

    RectTransform drawableRect;
    Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        drawableRect = GetComponent<RectTransform>();
        initialPosition = drawableRect.localPosition;
        StartCoroutine(ScrollText());
    }

    IEnumerator ScrollText()
    {
        while (drawableRect.localPosition.y < finalHeight) {
            drawableRect.Translate(Vector3.up * speed * Time.deltaTime);
            if (loop && drawableRect.localPosition.y > finalHeight) {
                drawableRect.localPosition = initialPosition;
            }
            yield return null;
        }
    }
}
