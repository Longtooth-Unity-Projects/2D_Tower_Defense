using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static Action<int> StarsUpdated;
    public static Action<int> HealthUpdated;
    public static Action LevelTimerExpired;

    // configuration variables
    private bool timerComplete = false;

    [Tooltip("Amount of stars the player starts with.")]
    [SerializeField] private int numOfStars = 10;

    [Tooltip("Initial health the player starts with.")]
    [SerializeField] private int health = 50;

    [Tooltip("Duration of the level in seconds.")]
    [SerializeField] private float levelDurationInSec = 10f;

    [Tooltip("How often the level manager checks to see if level timer is complete.")]
    [SerializeField] private float checkTimerDelay = 0.2f;

    [Tooltip("Delay before we change scenes.")]
    [SerializeField] private float sceneChangeDelay = 10f;

    [SerializeField] private int numOfAttackers = 0;    // TODO: serialized for debugging.

    [SerializeField] private GameObject levelCompleteCanvas;
    [SerializeField] AudioClip levelCompleteClip;

    // ***** core functions

    private void Start()
    {
        levelCompleteCanvas.SetActive(false);
        StartCoroutine(CheckTimer());
    }


    //*****misc methods
    private IEnumerator CheckTimer()
    {
        //due to delay of spawns and destruction, no need to check this every update, so we have an adjustable check routine
        while (Time.timeSinceLevelLoad <= levelDurationInSec)
        {
            yield return new WaitForSeconds(checkTimerDelay);
        }
        timerComplete = true;
        LevelTimerExpired?.Invoke();
    }// end of method CheckWinConditions


    //*****health display
    public void AdjustHealth(int adjustAmount)
    {
        health += adjustAmount;
        HealthUpdated?.Invoke(health);
        if (health <= 0)
        {
            FindObjectOfType<SceneLoader>().LoadGameOverScene();
        }
    }

    //*****star display
    public bool bHasEnoughStars(int amount) { return numOfStars >= amount; }


    public void AddStars(int amountToAdd)
    {
        numOfStars += amountToAdd;
        StarsUpdated?.Invoke(numOfStars);
    }


    public void SpendStars(int amount)
    {
        if (numOfStars >= amount)
        {
            numOfStars -= amount;
            StarsUpdated?.Invoke(numOfStars);
        }
    }

    //*****attacker tracking
    public void AddAttacker() { numOfAttackers++; }

    public void RemoveAttacker() 
    {
        numOfAttackers--;

        if ((numOfAttackers <= 0) && timerComplete)
            StartCoroutine(HandleWinCondition());
    }



    IEnumerator HandleWinCondition()
    {
        levelCompleteCanvas.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(levelCompleteClip);
        yield return new WaitForSeconds(sceneChangeDelay);
        FindObjectOfType<SceneLoader>().LoadNextScene();
    }


    public int GetNumOfStars() { return numOfStars; }
    public int GetHealth() { return health; }
    public float GetLevelDuration() { return levelDurationInSec; }
}
