using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Header("Attacker Fields")]
    [Tooltip("Amount of damage caused each attack period indicated by the attack speed.")]
    [Range(0, 50)] [SerializeField] int meleeDamage = 1;
    [Range(1, 5)] [SerializeField] float meleeAttackDelay = 0.5f;
    [Range(0f, 5f)] [SerializeField] float movementSpeed = 1f;
    private float currentMovementSpeed = 0f;

    [Header("Health Fields")]
    [SerializeField] private int health = 1;
    [SerializeField] private GameObject deathVFX;
    [SerializeField] private float vfxDestructionDelay = 1f;


    //cached references
    private Animator myAnimator;
    private Defender currentTarget;


    //***** core functios
    private void Awake()
    {
        FindObjectOfType<LevelManager>().AddAttacker();
    }

    private void Start()
    {
        currentMovementSpeed = movementSpeed;
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //move each frame
        transform.Translate(Vector2.left * Time.deltaTime * currentMovementSpeed);  // TODO: see if rigid body method by making start move and stop move functions is more efficient.
    }


    private void OnDestroy()
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        if (levelManager != null)
            levelManager.RemoveAttacker();
    }




    // ***** misc functions


    //***** attack series of animations
    /// <summary>
    /// If this is called, it is from the specific behavior script attached to the object (i.e. the lizard behavior script)
    /// </summary>
    /// <param name="targetDefender"></param>
    public IEnumerator Attack(Defender targetDefender)
    {
        myAnimator.SetBool("bIsAttacking", true);

        while (targetDefender)
        {
            targetDefender.TakeDamage(meleeDamage);
            yield return new WaitForSeconds(meleeAttackDelay);
        }

        myAnimator.SetBool("bIsAttacking", false);
    }

    /// <summary>
    /// Called from animation
    /// </summary>
    public void StartMove() { currentMovementSpeed = movementSpeed; }

    /// <summary>
    /// Called from animation
    /// </summary>
    public void StopMove() { currentMovementSpeed = 0f; }


    //*****Health Functions
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            ProcessDestruction();
    }

    private void ProcessDestruction()
    {
        if (deathVFX)
        {
            GameObject destructionVFXobj = Instantiate(deathVFX, transform.position, transform.rotation);
            destructionVFXobj.transform.parent = LevelManager.VFXContainer.transform;
            Destroy(destructionVFXobj, vfxDestructionDelay);
        }
        //AudioSource.PlayClipAtPoint(destructionClip, Camera.main.transform.position, destructionVolumeLevel);
        Destroy(gameObject);
    }


    //***** setters/getters

    public void SetCurrentMovementSpeed(float newSpeed) { currentMovementSpeed = newSpeed; }

    public int GetDamage() { return meleeDamage; }

}
