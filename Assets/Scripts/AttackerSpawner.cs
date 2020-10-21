using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackerSpawner : MonoBehaviour
{
    //configuration parameters
    [SerializeField] private float minSpawnTime = 2f;
    [SerializeField] private float maxSpawnTime = 5f;
    [SerializeField] private Attacker[] attackerPrefabs;

    private int numOfPrefabs = 0;
    private int attackerIndex = 0;
    private int lane = 0;


    [SerializeField] bool canSpawn = true;  // TODO: serialized for testing


    //***** core functions
    private void OnEnable()
    {
        //register listeners
        LevelManager.LevelTimerExpired += StopSpawning;
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        numOfPrefabs = attackerPrefabs.Length;
        lane = Mathf.RoundToInt(transform.position.y);

        while (canSpawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            spawnAttacker();
        }

    }

    private void OnDisable()
    {
        //remove listeners
        LevelManager.LevelTimerExpired -= StopSpawning;
    }



    // ***** misc functions
    private void spawnAttacker()
    {
        // Pick attacker
        attackerIndex = Random.Range(0, numOfPrefabs);

        // Spawn
        Attacker newAttacker = Instantiate(attackerPrefabs[attackerIndex], transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;
    }

    private void StopSpawning() 
    { 
        canSpawn = false;
        StopAllCoroutines();
    }

    public int GetLane() { return lane; }
}
