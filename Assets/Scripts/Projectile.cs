using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Configuration Parameters")]
    ///negative speed for left moving positive speed for right moving
    [SerializeField] float projectileSpeed = 3f;
    [SerializeField] float spinDegPerSec = -200f;
    [SerializeField] int damage = 1;

    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(projectileSpeed, 0);
        rb.angularVelocity = spinDegPerSec;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Attacker attacker = other.GetComponent<Attacker>();

        if (attacker)
        {
            attacker.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
