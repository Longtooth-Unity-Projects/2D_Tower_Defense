using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 3f;
    [SerializeField] float spinSpeed = 3f;

    private void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed);
        //transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
        //projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed * (int)direction);
    }
}
