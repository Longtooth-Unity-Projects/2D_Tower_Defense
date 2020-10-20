using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0, 5)] [SerializeField] int damage = 1;
    [Range(0f, 5f)] [SerializeField] float movementSpeed = 1f;
    private float currentMovementSpeed = 0f;


    //cached references
    private Animator myAnimator;
    private Defender currentTarget;


    private void Start()
    {
        currentMovementSpeed = movementSpeed;
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //move each frame
        transform.Translate(Vector2.left * Time.deltaTime * currentMovementSpeed);  // TODO: Remove this from update. Use rigid body method by making start move and stop move functions.
    }


    public void StartMove()
    {
        currentMovementSpeed = movementSpeed;
    }

    public void StopMove()
    {
        currentMovementSpeed = 0f;
    }

    /// <summary>
    /// If this is called, it is from the specific behavior script attached to the object (i.e. the lizard behavior script)
    /// </summary>
    /// <param name="targetDefender"></param>
    public void Attack(Defender targetDefender)
    {
        myAnimator.SetBool("bIsAttacking", true);
        currentTarget = targetDefender;
    }

    /// <summary>
    /// This gets called via an attack animation event
    /// </summary>
    public void AnimatorDamageTarget()
    {
        if (!currentTarget) 
        {
            myAnimator.SetBool("bIsAttacking", false);
            return; 
        }

        Health targetHealth = currentTarget.GetComponent<Health>();
        if (targetHealth)
            targetHealth.TakeDamage(damage);
    }


    private void AnimatorCheckTarget()
    {
        if (!currentTarget)
            myAnimator.SetBool("bIsAttacking", false);
    }

    public void SetCurrentMovementSpeed(float newSpeed)
    {
        currentMovementSpeed = newSpeed;
    }

    public int GetDamage() { return damage; }

}
