using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DefenderButton : MonoBehaviour
{
    //configuration parameters
    [SerializeField] private Defender defenderPrefab;
    private DefenderButton[] defenderButtons;
    private Color32 inactiveColor = new Color32(128, 0, 0, 255);

    //cached references
    DefenderSpawner defenderSpawner;

    private void Start()
    {
        GetComponentInChildren<Text>().text = defenderPrefab.GetCost().ToString();
        defenderButtons = FindObjectsOfType<DefenderButton>();
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
    }
    private void OnMouseDown()
    {
        foreach (DefenderButton defenderButton in defenderButtons)
        {
            defenderButton.GetComponent<SpriteRenderer>().color = inactiveColor;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        defenderSpawner.SetDefenderToSpawn(defenderPrefab);
    }
}
