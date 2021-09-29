using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThiefAttackBehaviour : PlayerAttackBehaviour
{
    attackCollider collider;

    [SerializeField]
    float impulseStrength = 50f;
    [SerializeField]
    float bscDmgMod = 0.5f;

    protected override void Awake()
    {
        base.Awake();
        collider = GetComponentInChildren<attackCollider>();

    }
    public override void OnBasicAttack(InputAction.CallbackContext context)
    {
        if(context.started && inputDelayTimer <= 0)
        {
            inputDelayTimer = inputDelay;

            anim.SetFloat("AttackSpeed", attackSpeed);
            anim.SetTrigger("attackb");
            collider.SetColliderValues(inputDelay, stats.Strength * bscDmgMod, inputDelay * colliderDelay);
        }
    }

    public override void OnDefend(InputAction.CallbackContext context)
    {
        if(context.started)
        { 
             defending = true;
            anim.SetBool("Defending", true);
            OnTurnEnd(false);
        }
    }

    public override void OnSpecial1(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            OnTurnEnd(false);
        }
    }

    public override void OnSpecial2(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            OnTurnEnd(false);
        }
    }

}
