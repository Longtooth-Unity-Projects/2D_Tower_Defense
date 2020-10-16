﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Projectile projectile;
    [SerializeField] private GameObject weapon;
    private int myLane = 0;
    private AttackerSpawner myLaneSpawner;

    //chached references
    Animator myAnimator;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();

        myLane = Mathf.RoundToInt(transform.position.y);
        SetLaneSpawner();
    }


    private void Update()
    {
        if (myLaneSpawner.transform.childCount > 0)
        {
            myAnimator.SetBool("bIsAttacking", true);
        }
        else
        {
            myAnimator.SetBool("bIsAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in attackerSpawners)
            if (myLane == spawner.GetLane())
                myLaneSpawner = spawner;
    }

    public void ShootProjectile()
    {
        Instantiate(projectile, weapon.transform.position, weapon.transform.rotation);
    }
}
