using System;
using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static Action<int> StarsUpdated;
    public static Action<int> HealthUpdated;
    public static Action LevelTimerExpired;

    private const string DEFENDER_CONTAINER_NAME = "DefenderContainer";
    private const string PROJECTILE_CONTAINER_NAME = "ProjectileContainer";
    private const string VFX_CONTAINER_NAME = "VFXContainer";

    public static GameObject DefenderContainer { get; private set; }
    public static GameObject ProjectileContainer { get; private set; }
    public static GameObject VFXContainer { get; private set; }

    private bool timerComplete = false;
    private int numOfAttackers = 0;


    // configuration variables
    [Tooltip("Amount of stars the player starts with.")]
    [SerializeField] private int baseStars = 40;

    [Tooltip("Initial health the player starts with.")]
    [SerializeField] private int baseHealth = 50;

    [Tooltip("Duration of the level in seconds.")]
    [SerializeField] private float baseLevelDuration = 60f;

    [Tooltip("How often the level manager checks to see if level timer is complete.")]
    [SerializeField] private float checkTimerDelay = 0.2f;

    [Tooltip("Delay before we change scenes.")]
    [SerializeField] private float sceneChangeDelay = 7f;

    [SerializeField] private GameObject levelCompleteCanvas;
    [SerializeField] private GameObject levelLoseCanvas;
    [SerializeField] AudioClip levelSuccessClip;
    [SerializeField] AudioClip levelFailClip;

    private int health;
    private int stars;
    private float levelDuration;

    // ***** core functions

    private void Start()
    {
        levelCompleteCanvas.SetActive(false);
        levelLoseCanvas.SetActive(false);

        AdjustDifficulty();

        DefenderContainer = new GameObject(DEFENDER_CONTAINER_NAME);
        ProjectileContainer = new GameObject(PROJECTILE_CONTAINER_NAME);
        VFXContainer = new GameObject(VFX_CONTAINER_NAME);

    StartCoroutine(CheckTimer());
    }

    private void AdjustDifficulty()
    {
        float difficultyIncreasesValue = 1f;
        float difficultyDecreasesValue = 1f;

        switch (PlayerPrefsController.GetDifficulty())
        {
            case 0:
                difficultyIncreasesValue = 0.5f;
                difficultyDecreasesValue = 1.5f;
                break;
            case 1:
                difficultyIncreasesValue = 1f;
                difficultyDecreasesValue = 1f;
                break;
            case 2:
                difficultyIncreasesValue = 1.5f;
                difficultyDecreasesValue = 1f;
                break;
            case 3:
                difficultyIncreasesValue = 2f;
                difficultyDecreasesValue = 0.5f;
                break;
            default:
                break;
        }// end of switch

        health = Mathf.RoundToInt(baseHealth * difficultyDecreasesValue);
        stars = Mathf.RoundToInt(baseStars * difficultyDecreasesValue);
        levelDuration = Mathf.RoundToInt(baseLevelDuration * difficultyIncreasesValue);
    }


    //*****misc methods
    private IEnumerator CheckTimer()
    {
        //due to delay of spawns and destruction, no need to check this every update, so we have an adjustable check routine
        while (Time.timeSinceLevelLoad <= levelDuration)
        {
            yield return new WaitForSeconds(checkTimerDelay);
        }
        timerComplete = true;
        LevelTimerExpired?.Invoke();
        if (numOfAttackers <= 0)
            HandleWinCondition();
    }// end of method CheckTimer


    //*****health display
    public void AdjustHealth(int adjustAmount)
    {
        health += adjustAmount;
        HealthUpdated?.Invoke(health);
        if (health <= 0)
        {
            HandleLooseCondition();
        }
    }

    //*****star display
    public bool bHasEnoughStars(int amount) { return stars >= amount; }


    public void AddStars(int amountToAdd)
    {
        stars += amountToAdd;
        StarsUpdated?.Invoke(stars);
    }


    public void SpendStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            StarsUpdated?.Invoke(stars);
        }
    }

    //*****attacker tracking
    public void AddAttacker() { numOfAttackers++; }

    public void RemoveAttacker() 
    {
        numOfAttackers--;

        if ((numOfAttackers <= 0) && timerComplete)
            HandleWinCondition();
    }



    private void HandleWinCondition()
    {
        levelCompleteCanvas.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(levelSuccessClip);
    }

    private void HandleLooseCondition()
    {
        Time.timeScale = 0;
        levelLoseCanvas.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(levelFailClip);
    }


    public int GetNumOfStars() { return stars; }
    public int GetHealth() { return health; }
    public float GetLevelDuration() { return levelDuration; }
}
