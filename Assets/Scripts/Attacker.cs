using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)] [SerializeField] float walkspeed = 1f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move each frame
        transform.Translate(Vector2.left * Time.deltaTime * walkspeed);
    }
}
