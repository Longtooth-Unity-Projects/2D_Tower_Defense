using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class DefenderSpawner : MonoBehaviour
{
    private Defender defenderToSpawn;

    //cached references
    LevelManager levelManager;


    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnMouseDown()
    {
        if (defenderToSpawn && levelManager.bHasEnoughStars(defenderToSpawn.GetCost()))
        {
            SpawnDefender(GetClickToWorldPos());
        }
    }


    private void SpawnDefender(Vector2 worldPos)
    {
        Defender newDefender = Instantiate(defenderToSpawn, worldPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = LevelManager.DefenderContainer.transform;
        levelManager.SpendStars(defenderToSpawn.GetCost());
    }

    private Vector2 GetClickToWorldPos()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        clickPos = Camera.main.ScreenToWorldPoint(clickPos);

        //do this to center defender in grid square
        clickPos.x = Mathf.RoundToInt(clickPos.x);
        clickPos.y = Mathf.RoundToInt(clickPos.y);
        return clickPos;
    }

    public void SetDefenderToSpawn(Defender defenderChoice) { defenderToSpawn = defenderChoice; }
}
