using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] Defender defender; //TODO serialized for debugging purposes

    //cached references
    [SerializeField] StarDisplay starDisplay;


    private void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    private void OnMouseDown()
    {
        if (starDisplay.bHasEnoughStars(defender.GetCost()))
        {
            Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            clickPos = Camera.main.ScreenToWorldPoint(clickPos);

            //do this to center defender in grid square
            clickPos.x = Mathf.RoundToInt(clickPos.x);
            clickPos.y = Mathf.RoundToInt(clickPos.y);
            SpawnDefender(clickPos);
        }
    }


    private void SpawnDefender(Vector2 worldPos)
    {
        GameObject newDefender = Instantiate(defender.gameObject, worldPos, Quaternion.identity) as GameObject;
        starDisplay.SpendStars(defender.GetCost());
    }

    public void SetDefender(Defender defenderChoice) { defender = defenderChoice; }
}
