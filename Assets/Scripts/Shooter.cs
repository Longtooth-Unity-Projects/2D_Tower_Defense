using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Projectile projectile;
    [SerializeField] private GameObject gun;

    private void Start()
    {
        //
    }

    public void ShootProjectile()
    {
        Instantiate(projectile, gun.transform.position, gun.transform.rotation);
    }
}
