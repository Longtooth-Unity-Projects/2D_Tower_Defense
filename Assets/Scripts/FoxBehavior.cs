using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;


        Defender possibleDefender = otherObject.GetComponent<Defender>();
        if (possibleDefender)
        {
            if (possibleDefender.GetComponent<GravestoneBehavior>())
                GetComponent<Animator>().SetTrigger("JumpTrigger");
            else
                StartCoroutine(GetComponent<Attacker>().Attack(possibleDefender));
        }
    }// end of method OnTriggerEnter2D
}
