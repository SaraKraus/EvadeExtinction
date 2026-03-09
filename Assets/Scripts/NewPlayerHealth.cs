using UnityEngine;

public class NewPlayerHealth : MonoBehaviour, IDamageable
{
    public int health;
    public int maxHealth = 10;
    
    //---------------
    float currentHealth;
    SpriteRenderer sprite;

    void Start()
    {
        health = maxHealth;
    }

    /*public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }*/

    public bool ApplyDamage(float amount)
    {
        if (currentHealth <= 0f)
            return false;

        currentHealth -= amount;

        if (currentHealth <= 0f)
        {
            Die();
            return true;
        }

        return true;
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}