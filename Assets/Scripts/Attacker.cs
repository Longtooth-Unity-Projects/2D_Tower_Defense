using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)] [SerializeField] float currentMovementSpeed = 1f;
    //[SerializeField] int health = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move each frame
        transform.Translate(Vector2.left * Time.deltaTime * currentMovementSpeed);
    }

/*    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProcessHit(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ProcessHit(collision);
    }*/

/*    private void ProcessHit(Collider2D otherCollider)
    {
        Projectile projectile = otherCollider.GetComponent<Projectile>();
        if (projectile)
        {
            health -= projectile.GetDamage();
            projectile.OnHit();
            if (health < 0)
            {
                ProcessDestruction();
            }
        }
    }*/

    private void ProcessDestruction()
    {
        //Destroyed?.Invoke(scoreValue);
        //GameObject explosion = Instantiate(explosionVFX, transform.position, transform.rotation);
        //AudioSource.PlayClipAtPoint(destructionClip, Camera.main.transform.position, destructionVolumeLevel);
        //Destroy(explosion, explosionDuration);
        Destroy(gameObject);
    }

    public void SetMovementSpeed(float newSpeed) { currentMovementSpeed = newSpeed; }
}
