using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Duration of the Level in Seconds.")]
    [SerializeField] float levelDurationInSec = 10f;


    private void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelDurationInSec;

        if (Time.timeSinceLevelLoad >= levelDurationInSec)
        {
            Debug.Log("Level Finished!");
        }
    }
}
