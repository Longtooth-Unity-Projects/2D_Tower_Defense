using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private int health;
    [SerializeField] private int numOfStars;
    [SerializeField] private float levelDurationInSec;

    // cached references
    LevelManager levelManager;

    TextMeshProUGUI healthText;
    TextMeshProUGUI starText;
    Slider slider;

    private void OnEnable()
    {
        //add listeners
        LevelManager.StarsUpdated += UpdateStarDisplay;
        LevelManager.HealthUpdated += UpdateHealthDisplay;
    }

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

        healthText = transform.Find("HealthText (TMP)").GetComponent<TextMeshProUGUI>();
        starText = transform.Find("StarText (TMP)").GetComponent<TextMeshProUGUI>();
        slider = transform.Find("Slider").GetComponent<Slider>();

        levelDurationInSec = levelManager.GetLevelDuration();
    }

    private void Update()
    {
        slider.value = Time.timeSinceLevelLoad / levelDurationInSec;

        if (Time.timeSinceLevelLoad >= levelDurationInSec)
        {
            levelManager.LevelFinished();
        }
    }


    private void OnDisable()
    {
        // remove listeners
        LevelManager.StarsUpdated -= UpdateStarDisplay;
        LevelManager.HealthUpdated -= UpdateHealthDisplay;
    }


    //******** display updates

    private void UpdateHealthDisplay(int currentHealth)
    {
        healthText.text = currentHealth.ToString();
    }

    private void UpdateStarDisplay(int numOfStars)
    {
        starText.text = numOfStars.ToString();
    }

}
