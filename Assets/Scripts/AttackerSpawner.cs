using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackerSpawner : MonoBehaviour
{
    //configuration parameters
    [SerializeField] private float minSpawnTime = 2f;
    [SerializeField] private float maxSpawnTime = 5f;
    [SerializeField] private Attacker attackerPrefab;


    [SerializeField] bool canSpawn = true;  //serialized for testing

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (canSpawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            spawnAttacker();
        }

    }

    private void spawnAttacker()
    {
        Instantiate(attackerPrefab, transform.position, Quaternion.identity);
    }
}
