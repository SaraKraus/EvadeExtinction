using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float maxHealth = 100f;
    public string Level;
    //[SerializeField] float invulnerabilityDuration = 1f;
    //[SerializeField] float blinkInterval = 0.1f;

    float currentHealth;
    //float invulnerabilityTimer;

    SpriteRenderer sprite;
    //float blinkTimer;
    //bool blinking;

    [SerializeField] private ObjectManager objectManager;


    Vector2 startPos;
    SpriteRenderer spriteRenderer;

     void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPos = transform.position;
        currentHealth = maxHealth;
        sprite = GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Flames"))
        {
            Die();
            if (ObjectManager.Instance != null)
                ObjectManager.Instance.ResetObjects();
        }
    }

    void Die()
    {
        SceneLoader.Instance.LoadScene(Level);
        StartCoroutine(Respawn(10f));
         if (MenuAudioManager.Instance != null && MenuAudioManager.Instance.deathSFX != null)
         {
         MenuAudioManager.Instance.PlaySFX(MenuAudioManager.Instance.deathSFX);
         }
    }

    IEnumerator Respawn(float duration)
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = startPos;
        spriteRenderer.enabled = true;
    }

   

   

    /*void Update()
    {
        if (invulnerabilityTimer > 0f)
            invulnerabilityTimer -= Time.deltaTime;

        HandleBlink();
    }*/

    public bool ApplyDamage(float amount)
    {
        if (currentHealth <= 0f/* || invulnerabilityTimer > 0f*/)
            return false;

        currentHealth -= amount;
        //CameraShakeManager.Instance.Shake(2f, 0.25f);

        if (currentHealth <= 0f)
        {
            Die();
            return true;

        }

        //invulnerabilityTimer = invulnerabilityDuration;
        //StartBlink(invulnerabilityDuration);
        return true;
    }

    /*void StartBlink(float duration)
    {
        blinking = true;
        blinkTimer = duration;
    }

    void HandleBlink()
    {
        if (!blinking) return;

        blinkTimer -= Time.deltaTime;
        if (blinkTimer <= 0f)
        {
            blinking = false;
            sprite.enabled = true;
            return;
        }

        sprite.enabled =
            Mathf.FloorToInt(blinkTimer / blinkInterval) % 2 == 0;
    }*/

   // void Die()
  //  {
  // }
}