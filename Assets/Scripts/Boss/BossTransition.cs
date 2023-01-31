/*
Motion of the boss to get into position for the battle
Used to make the boss enter the stage, as well as to make it move between
phases

Using smooth transitions for slerp as explained here:
https://gamedevbeginner.com/the-right-way-to-lerp-in-unity-with-examples/

Gilberto Echeverria
2023-01-30
*/

using UnityEngine;

public class BossTransition : MonoBehaviour
{
    public Vector3 initialPos;
    public Vector3 finalPos;
    public Quaternion initialRot;
    public Quaternion finalRot;
    public float duration;

    bool isMoving = false;

    float elapsed;
    float t;

    public void StartTransition()
    {
        elapsed = 0;
        isMoving = true;
Debug.Log("Rotating from: " + initialRot);
    }

    // Update is called once per frame
    void Update()
    {
        // Test functionality
        if (Input.GetKeyDown(KeyCode.R)) {
            StartTransition();
        }

        if (isMoving) {
            ApplySlerp();
        }
    }

    void ApplySlerp()
    {
        t = elapsed / duration;
        t = t * t * (3f - 2f * t);

        transform.position = Vector3.Slerp(initialPos, finalPos, t);
        transform.rotation = Quaternion.Slerp(initialRot, finalRot, t);

        elapsed += Time.deltaTime;
        if (elapsed > duration) {
            elapsed = duration;
            isMoving = false;
Debug.Log("Rotating into: " + finalRot);
        }
    }
}