using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private GameObject deathVFX;
    [SerializeField] private float deathVFXdestructionDelay = 1f;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            ProcessDestruction();
    }

    private void ProcessDestruction()
    {
        if (deathVFX)
        {
            GameObject destructionVFXobj = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(destructionVFXobj, deathVFXdestructionDelay);
        }
        //Destroyed?.Invoke(scoreValue);
        //AudioSource.PlayClipAtPoint(destructionClip, Camera.main.transform.position, destructionVolumeLevel);
        Destroy(gameObject);
    }
}
