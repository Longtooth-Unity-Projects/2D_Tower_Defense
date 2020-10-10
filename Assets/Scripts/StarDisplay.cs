using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int numOfStars = 10;

    public bool bHasEnoughStars(int amount) { return numOfStars >= amount; }

    public void SpendStars(int amount) { numOfStars -= amount; }

    public int GetNumOfStarts() { return numOfStars; }
}
