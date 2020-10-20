using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private int cost = 1;

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


    public int GetCost() { return cost; }

}
