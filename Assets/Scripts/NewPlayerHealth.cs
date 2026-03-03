using UnityEngine;

public class NewPlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}