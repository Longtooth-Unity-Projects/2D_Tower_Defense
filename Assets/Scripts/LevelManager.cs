using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static Action<int> StarsUpdated;
    public static Action<int> HealthUpdated;

    [Tooltip("Amount of Stars the Player Starts With.")]
    [SerializeField] private int initialNumOfStars = 10;
    private int currentStars;

    [Tooltip("Initial Health the Player Starts With.")]
    [SerializeField] private int initialHealth = 50;
    private int currentHealth;

    [Tooltip("Duration of the Level in Seconds.")]
    [SerializeField] private float levelDurationInSec = 10f;


    private void Start()
    {
        currentStars = initialNumOfStars;
        StarsUpdated?.Invoke(currentStars);
        currentHealth = initialHealth;
        HealthUpdated?.Invoke(currentHealth);
    }


    //health display
    public void AdjustHealth(int adjustAmount)
    {
        currentHealth += adjustAmount;
        HealthUpdated?.Invoke(currentHealth);
        if (currentHealth <= 0)
        {
            FindObjectOfType<SceneLoader>().LoadGameOverScene();
        }
    }

    //star display
    public bool bHasEnoughStars(int amount) { return currentStars >= amount; }


    public void AddStars(int amountToAdd)
    {
        currentStars += amountToAdd;
        StarsUpdated?.Invoke(currentStars);
    }


    public void SpendStars(int amount)
    {
        if (currentStars >= amount)
        {
            currentStars -= amount;
            StarsUpdated?.Invoke(currentStars);
        }
    }


    public void LevelFinished()
    {
        Debug.Log("Level Finished!");
    }


    public int GetInitialStars() { return initialNumOfStars; }
    public int GetInitialHealth() { return initialHealth; }
    public float GetLevelDuration() { return levelDurationInSec; }
}
