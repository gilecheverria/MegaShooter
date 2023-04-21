/*
Script to control the general behaviour of a Boss enemy

Gilberto Echeverria
2023-01-30
*/

using System.Collections;
using UnityEngine;

public enum BossState { ENTRANCE, SINE, SPREAD, TRANS, MISSILES }
public enum BossCondition { OK, DAMAGED }

public class BossBehaviour : MonoBehaviour
{
    [SerializeField] BossState state;
    [SerializeField] BossCondition condition;
    [SerializeField] float entranceDuration;
    [SerializeField] float stateDuration;
    [SerializeField] Vector3 centerPos;
    [SerializeField] Vector3 backPos;

    // References to other components that will be modified
    [SerializeField] Collider[] cols;
    [SerializeField] SineMovement sinMov;
    [SerializeField] BossWeapon bossWeap;
    [SerializeField] BossWeaponSpread bossSpread;
    [SerializeField] BossTransition bossTransit;
    [SerializeField] BossMissiles bossMissiles;
    [SerializeField] GameObject shield;

    Health health;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();

        // Initial state to use. Only for debugging
        if (state == BossState.ENTRANCE)
            StartCoroutine(Entrance());
        else if (state == BossState.SINE)
            StartCoroutine(ToSine());
        else if (state == BossState.SPREAD)
            StartCoroutine(ToSpread());
        else if (state == BossState.TRANS)
            StartCoroutine(ToCenter());
        else if (state == BossState.MISSILES)
            StartCoroutine(ToBack());
    }

    // Set the entrance of the boss ship. It is invulnerable during this state
    IEnumerator Entrance()
    {
        bossTransit.enabled = true;
        bossTransit.finalPos = centerPos;
        bossTransit.duration = entranceDuration;
        bossTransit.StartTransition();

        yield return new WaitForSeconds(entranceDuration);

        bossTransit.enabled = false;
        //state = BossState.SINE; 
        //StartCoroutine(ToSine());
        NextAttack();
    }

    // Randomly chose from the available attack patters
    void NextAttack()
    {
        if(condition == BossCondition.OK) {
            CheckHealth();
        }

        int attack = Random.Range(0, 10);

        if(attack < 4) {
            // Sine attack
            state = BossState.SINE;
            StartCoroutine(ToSine());
        } else if(attack < 7) {
            // Spread attack
            state = BossState.SPREAD;
            StartCoroutine(ToCenter());
        } else {
            // Missile attack
            state = BossState.MISSILES;
            StartCoroutine(ToBack());
        }
    }

    // Decrease time between attacks when health is less than half
    void CheckHealth()
    {
        if(health.hp <= health.maxHP / 2) {
            condition = BossCondition.DAMAGED;
            stateDuration /= 2;
        }
    }

    // Move the boss back to the center position
    IEnumerator ToCenter()
    {
        shield.SetActive(true);
        bossTransit.enabled = true;
        bossTransit.finalPos = centerPos;
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
        //state = BossState.TRANS;
        //StartCoroutine(ToCenter());
        NextAttack();
    }

    // Fire the central guns from the center
    IEnumerator ToSpread()
    {
        bossSpread.enabled = true;

        foreach (var col in cols)
            col.enabled = true;

        yield return new WaitForSeconds(stateDuration);

        bossSpread.enabled = false;
        //state = BossState.MISSILES; 
        //StartCoroutine(ToBack());
        NextAttack();
    }

    // Move the boss to the back of the screen to fire missiles
    IEnumerator ToBack()
    {
        shield.SetActive(true);
        bossTransit.enabled = true;
        bossTransit.finalPos = backPos;
        bossTransit.initialPos = transform.position;
        bossTransit.initialRot = transform.rotation;
        bossTransit.duration = 2f;
        bossTransit.StartTransition();

        yield return new WaitForSeconds(bossTransit.duration);

        shield.SetActive(false);
        bossTransit.enabled = false;
        state = BossState.MISSILES; 
        StartCoroutine(ToMissiles());
    }

    // Fire missiles that chase the player
    IEnumerator ToMissiles()
    {
        bossMissiles.enabled = true;

        foreach (var col in cols)
            col.enabled = true;

        yield return new WaitForSeconds(stateDuration / 2);

        bossMissiles.enabled = false;
        //state = BossState.SINE; 
        //StartCoroutine(ToCenter());
        NextAttack();
    }
}
