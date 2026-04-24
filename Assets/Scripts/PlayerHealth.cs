using UnityEngine;
using System.Collections;
using DG.Tweening;


[RequireComponent(typeof(SpriteRenderer))]
public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float strength = 0.5f;
    [SerializeField] float duration = 3f;

    public string Level;


    //[SerializeField] float invulnerabilityDuration = 1f;
    //[SerializeField] float blinkInterval = 0.1f;

    float currentHealth;
    //float invulnerabilityTimer;

    SpriteRenderer sprite;
    Rigidbody2D rb;
    private bool isDead;
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
        rb = GetComponent<Rigidbody2D>();

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
    if (isDead) return;
    isDead = true;

    rb.linearVelocity = Vector2.zero;
    rb.simulated = false;

    spriteRenderer.enabled = false; // hide player, but keep script alive

    if (CameraShakeManager.Instance != null)
        CameraShakeManager.Instance.Shake(10f, 6f);

    if (MenuAudioManager.Instance != null && MenuAudioManager.Instance.deathSFX != null)
        MenuAudioManager.Instance.PlaySFX(MenuAudioManager.Instance.deathSFX);

    StartCoroutine(Death());
}

IEnumerator Death()
{
    yield return new WaitForSeconds(0.5f);

    SceneLoader.Instance.LoadScene(Level);
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

        //CameraShake.Shake(duration = 3f, strength = 3f);

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