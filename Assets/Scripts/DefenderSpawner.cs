using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] GameObject defender;

    private void OnMouseDown()
    {
        // get position and round coordinates so spawnable is centered in grid square
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        clickPos = Camera.main.ScreenToWorldPoint(clickPos);
        clickPos.x = Mathf.RoundToInt(clickPos.x);
        clickPos.y = Mathf.RoundToInt(clickPos.y);
        SpawnDefender(clickPos);
    }


    private void SpawnDefender(Vector2 worldPos)
    {
        GameObject newDefender = Instantiate(defender, worldPos, Quaternion.identity) as GameObject;
    }
}
