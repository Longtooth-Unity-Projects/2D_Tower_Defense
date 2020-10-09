using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Configuration Parameters")]
    ///negative speed for left moving positive speed for right moving
    [SerializeField] float projectileSpeed = 3f;
    [SerializeField] float spinSpeed = 200f;
    [SerializeField] int damage = 1;

    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(projectileSpeed, 0);
        rb.angularVelocity = spinSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health health = other.GetComponent<Health>();
        Attacker attacker = other.GetComponent<Attacker>();

        if (health && attacker)
        {
            health.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
