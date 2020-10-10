using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)] [SerializeField] float currentMovementSpeed = 1f;


    // Update is called once per frame
    void Update()
    {
        //move each frame
        transform.Translate(Vector2.left * Time.deltaTime * currentMovementSpeed);
    }

    public void SetMovementSpeed(float newSpeed) { currentMovementSpeed = newSpeed; }
}
