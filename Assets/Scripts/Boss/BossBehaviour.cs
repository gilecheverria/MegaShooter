/*
Script to control the general behaviour of a Boss enemy

Gilberto Echeverria
2023-01-30
*/

using System.Collections;
using UnityEngine;

public enum BossState { ENTRANCE, SINE, SPREAD, TRANS }

public class BossBehaviour : MonoBehaviour
{
    [SerializeField] BossState state;

    // References to other components that will be modified
    [SerializeField] Collider[] cols;
    [SerializeField] SineMovement sinMov;
    [SerializeField] BossWeapon bossWeap;
    [SerializeField] BossWeaponSpread bossSpread;
    [SerializeField] BossTransition bossTransit;
    [SerializeField] GameObject shield;
    [SerializeField] float entranceDuration;
    [SerializeField] float stateDuration;

    // Start is called before the first frame update
    void Start()
    {
        if (state == BossState.ENTRANCE)
            StartCoroutine(Entrance());
        else if (state == BossState.SINE)
            StartCoroutine(ToSine());
        else if (state == BossState.SPREAD)
            StartCoroutine(ToSpread());
        else if (state == BossState.TRANS)
            StartCoroutine(ToCenter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Set the entrance of the boss ship. It is invulnerable during this state
    IEnumerator Entrance()
    {
        bossTransit.enabled = true;
        bossTransit.duration = entranceDuration;
        bossTransit.StartTransition();

        yield return new WaitForSeconds(entranceDuration);

        bossTransit.enabled = false;
        state = BossState.SINE; 
        StartCoroutine(ToSine());
    }

    // Move the boss back to the center position
    IEnumerator ToCenter()
    {
        shield.SetActive(true);
        bossTransit.enabled = true;
        bossTransit.initialPos = transform.position;
        bossTransit.initialRot = transform.rotation;
        bossTransit.duration = 2f;
        bossTransit.StartTransition();

        yield return new WaitForSeconds(bossTransit.duration);

        shield.SetActive(false);
        bossTransit.enabled = false;
        state = BossState.SPREAD; 
        StartCoroutine(ToSpread());
    }

    // Move sideways and fire side guns
    IEnumerator ToSine()
    {
        bossWeap.enabled = true;
        sinMov.enabled = true;

        foreach (var col in cols)
            col.enabled = true;
        
        yield return new WaitForSeconds(stateDuration);

        bossWeap.enabled = false;
        sinMov.enabled = false;
        state = BossState.TRANS;
        StartCoroutine(ToCenter());
    }

    // Fire the central guns from the center
    IEnumerator ToSpread()
    {
        bossSpread.enabled = true;

        foreach (var col in cols)
            col.enabled = true;

        yield return new WaitForSeconds(stateDuration);

        bossSpread.enabled = false;
        state = BossState.SINE; 
        StartCoroutine(ToSine());
    }
}
