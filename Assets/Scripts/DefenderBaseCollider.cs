using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class DefenderBaseCollider : MonoBehaviour
{
    LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Attacker possibleAttacker = otherCollider.gameObject.GetComponent<Attacker>();

        if (possibleAttacker)
        {
            levelManager.AdjustHealth(-1 * possibleAttacker.GetDamage());
        }
    }
}
