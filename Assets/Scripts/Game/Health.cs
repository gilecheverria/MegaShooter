/*
Script to keep control of the hitpoints of a game object

Gilberto Echeverria
2022-12-14
*/

using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int worth = 1;
    [SerializeField] GameObject explosion;
    [SerializeField] HealthBar bar;
    [SerializeField] bool isBoss;

    public int maxHP = 1;
    public int hp;
    //bool alive;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;    
        //alive = true;
        if (bar != null) {
            bar.Init(maxHP);
        }
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;
        if (hp <= 0) {
            hp = 0;
            Die();
        }
        if (bar != null) {
            bar.SetValue(hp);
        }
    }

    void Die()
    {
        //alive = false;

        ScoreManager.score += worth;
        //Debug.Log("New score: " + ScoreManager.score);

        // If a prefab for the explosion exists, create it and doom it to die
        if (explosion != null) {
            GameObject temp = Instantiate(explosion,
                                          transform.position,
                                          Quaternion.identity);
            Destroy(temp, 2);
        }

        if (isBoss) {
            // In the case of a boss, go to the next scene
            Invoke("GoToGameOver", 1.0f);
        } else {
            // Destroy the enemy
            Destroy(gameObject);
        }
    }

    void GoToGameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
}