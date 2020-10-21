using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private float levelDurationInSec;

    // cached references
    LevelManager levelManager;

    TextMeshProUGUI healthText;
    TextMeshProUGUI starText;
    Slider slider;
    bool levelFinished = false;

    private void OnEnable()
    {
        //add listeners
        LevelManager.StarsUpdated += UpdateStarDisplay;
        LevelManager.HealthUpdated += UpdateHealthDisplay;
        LevelManager.LevelTimerExpired += LevelFinished;
    }

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

        healthText = transform.Find("HealthText (TMP)").GetComponent<TextMeshProUGUI>();
        starText = transform.Find("StarText (TMP)").GetComponent<TextMeshProUGUI>();
        slider = transform.Find("Slider").GetComponent<Slider>();

        levelDurationInSec = levelManager.GetLevelDuration();
        UpdateHealthDisplay(levelManager.GetHealth());
        UpdateStarDisplay(levelManager.GetNumOfStars());

        StartCoroutine(UpdateSlider());
    }


    private void OnDisable()
    {
        // remove listeners
        LevelManager.StarsUpdated -= UpdateStarDisplay;
        LevelManager.HealthUpdated -= UpdateHealthDisplay;
        LevelManager.LevelTimerExpired -= LevelFinished;
    }


    //******** misc functions
    private IEnumerator UpdateSlider()
    {
        while (!levelFinished)
        {
            slider.value = Time.timeSinceLevelLoad / levelDurationInSec;
            yield return null;
        }
    }

    private void UpdateHealthDisplay(int currentHealth)
    {
        healthText.text = currentHealth.ToString();
    }

    private void UpdateStarDisplay(int numOfStars)
    {
        starText.text = numOfStars.ToString();
    }

    private void LevelFinished() { levelFinished = true; }

}
