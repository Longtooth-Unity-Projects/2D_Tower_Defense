﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [Header("Defender Fields")]
    [SerializeField] private int cost = 1;
    [Tooltip("Amount of damage caused each attack period indicated by the attack speed.")]
    [Range(0, 50)] [SerializeField] int meleeDamage = 1;
    [Range(1, 5)] [SerializeField] float attackDelay = 0.5f;

    [Header("Health Fields")]
    [SerializeField] private int health = 1;
    [SerializeField] private GameObject deathVFX;
    [SerializeField] private float vfxDestructionDelay = 1f;

    //cached references
    LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void IncreaseStars(int amountToIncrease) 
    {
        levelManager.AddStars(amountToIncrease);
    }

    //*****Health Functions
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
            destructionVFXobj.transform.parent = LevelManager.VFXContainer.transform;
            Destroy(destructionVFXobj, vfxDestructionDelay);
        }
        //AudioSource.PlayClipAtPoint(destructionClip, Camera.main.transform.position, destructionVolumeLevel);
        Destroy(gameObject);
    }

    //***** Setters/Getters
    public int GetCost() { return cost; }

}
