using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravestoneBehavior : MonoBehaviour
{
    private Animator myAnimator;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    //TODO: finish this by connecting with pulse animation
    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        if(otherCollider.GetComponent<Attacker>())
            myAnimator.SetBool("bIsBeingAttacked", true);
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        myAnimator.SetBool("bIsBeingAttacked", false);
    }
}
