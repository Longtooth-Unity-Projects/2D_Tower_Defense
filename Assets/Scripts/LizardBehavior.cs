﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        Defender possibleDefender = otherObject.GetComponent<Defender>();
        if (possibleDefender)
        {
            GetComponent<Attacker>().Attack(possibleDefender);
        }
    }
}