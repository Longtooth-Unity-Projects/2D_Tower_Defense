using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DefenderButton : MonoBehaviour
{
    private DefenderButton[] defenderButtons;
    private Color32 inactiveColor = new Color32(128, 0, 0, 255);

 
    private void Start()
    {
        defenderButtons = FindObjectsOfType<DefenderButton>();
    }
    private void OnMouseDown()
    {
        foreach (DefenderButton defenderButton in defenderButtons)
        {
            defenderButton.GetComponent<SpriteRenderer>().color = inactiveColor;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
