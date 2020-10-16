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
    private int lane = 0;


    [SerializeField] bool canSpawn = true;  //serialized for testing

    // Start is called before the first frame update
    IEnumerator Start()
    {
        lane = Mathf.RoundToInt(transform.position.y);

        while (canSpawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            spawnAttacker();
        }

    }

    private void spawnAttacker()
    {
        Attacker newAttacker = Instantiate(attackerPrefab, transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;
    }

    public int GetLane() { return lane; }
}
