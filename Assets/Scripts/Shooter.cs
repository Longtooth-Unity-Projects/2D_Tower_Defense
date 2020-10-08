using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Projectile projectile;
    [SerializeField] private GameObject weapon;


    public void ShootProjectile()
    {
        Instantiate(projectile, weapon.transform.position, weapon.transform.rotation);
    }
}
