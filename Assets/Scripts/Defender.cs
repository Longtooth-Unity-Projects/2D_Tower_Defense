using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private int cost = 1;


    public void IncreaseStars(int amountToIncrease) 
    {
        FindObjectOfType<StarDisplay>().AddStars(amountToIncrease);
    }


    public int GetCost() { return cost; }

}
