using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHP = 1;
    [SerializeField] int worth = 1;

    int hp;
    bool alive;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;    
        alive = true;
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;
        if (hp <= 0) {
            Die();
        }
    }

    void Die()
    {
        alive = false;

        ScoreManager.score += worth;
        //Debug.Log("New score: " + ScoreManager.score);

        // Destroy the enemy
        Destroy(gameObject);
    }
}
