/*
Script to keep control of the hitpoints of a game object

Gilberto Echeverria
2022-12-14
*/

using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHP = 1;
    [SerializeField] int worth = 1;
    [SerializeField] GameObject explosion;

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

        // If a prefab for the explosion exists, create it and doom it to die
        if (explosion != null) {
            GameObject temp = Instantiate(explosion,
                                          transform.position,
                                          Quaternion.identity);
            Destroy(temp, 2);
        }

        // Destroy the enemy
        Destroy(gameObject);
    }
}