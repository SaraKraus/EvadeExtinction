using UnityEngine;

public class NewEnemyDamage : MonoBehaviour
{
    public NewPlayerHealth newplayerHealth;
    public int damage = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            newplayerHealth.TakeDamage(damage);
        }
    }
}
