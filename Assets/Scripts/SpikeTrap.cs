using UnityEngine;

public class Flames : MonoBehaviour
{
    [SerializeField] float damage = 100f;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage(damage);
        }
    }
}