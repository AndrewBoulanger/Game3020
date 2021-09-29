using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public delegate void TurnOverDelegate(bool isDead);
public abstract class PlayerAttackBehaviour : MonoBehaviour
{
    protected Animator anim;
    public TurnOverDelegate OnTurnEnd;
    bool isDead = false;
    const float avgSpeed = 65f;


    protected CharacterStats stats;
    protected float attackSpeed;
    protected float colliderDelay = 0.4f;

    protected bool defending;

    protected float inputDelay = 0.70f;
    protected float inputDelayTimer = 0;

    TurnIndicatorEffects turnIndicatorCylinder;
    // Start is called before the first frame update
    protected virtual void Awake()
    {
       turnIndicatorCylinder = GetComponentInChildren<TurnIndicatorEffects>();
        anim = GetComponent<Animator>();
        stats = GetComponent<CharacterStats>();
        attackSpeed = 1 + ( (float)stats.Speed - avgSpeed) / avgSpeed;
       inputDelay *= 1/attackSpeed;
        colliderDelay = inputDelay * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //delay timer set in the overloaded basic attack function, prevents input spamming
        if(inputDelayTimer >= 0)
            inputDelayTimer -= Time.deltaTime;

        //if at any point the player is dead, end their turn immediately
        if(isDead)
            OnTurnEnd(true);
    }

    protected virtual void OnEnable()
    {
        if( turnIndicatorCylinder != null)
            turnIndicatorCylinder.gameObject.SetActive(true);
        else
            print("cylinder not found");

        if(defending)
        {
            defending = false;
            anim.SetBool("Defending", false);
        }
        
    }

    private void OnDisable()
    {
        if( turnIndicatorCylinder != null)
            turnIndicatorCylinder.gameObject.SetActive(false);
    }

    public abstract void OnBasicAttack(InputAction.CallbackContext context);
    public abstract void OnDefend(InputAction.CallbackContext context);
    public abstract void OnSpecial1(InputAction.CallbackContext context);
    public abstract void OnSpecial2(InputAction.CallbackContext context);
}
