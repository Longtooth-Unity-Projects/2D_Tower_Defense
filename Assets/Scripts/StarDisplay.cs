using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int numOfStars = 10;

    TextMeshProUGUI starText;

    private void Start()
    {
        starText = GetComponent<TextMeshProUGUI>();
        UpdateText();
    }

    public bool bHasEnoughStars(int amount) { return numOfStars >= amount; }

    private void UpdateText() { starText.text = numOfStars.ToString(); }

    public void AddStars(int amountToAdd) 
    { 
        numOfStars += amountToAdd;
        UpdateText();
    }

    public void SpendStars(int amount)
    {
        if (numOfStars >= amount)
        {
            numOfStars -= amount;
            UpdateText();
        }
    }

    public int GetNumOfStarts() { return numOfStars; }
}
