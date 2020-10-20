using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

// TODO: move this to attacker/defender classes, no need to keep it seperate as they all have health
public class Health : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private GameObject deathVFX;
    [SerializeField] private float vfxDestructionDelay = 1f;

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
            Destroy(destructionVFXobj, vfxDestructionDelay);
        }
        //Destroyed?.Invoke(scoreValue);
        //AudioSource.PlayClipAtPoint(destructionClip, Camera.main.transform.position, destructionVolumeLevel);
        Destroy(gameObject);
    }
}
