using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KnightAttackBehaviour : PlayerAttackBehaviour
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
            anim.SetTrigger("Attack");
            collider.SetColliderValues(inputDelay, stats.Strength * bscDmgMod, colliderDelay);
        }
    }

    public override void OnDefend(InputAction.CallbackContext context)
    {
        if (context.started && inputDelayTimer <= 0)
        {
            defending = true;
            anim.SetBool("Defending", true);
            OnTurnEnd(false);
        }
    }

    public override void OnSpecial1(InputAction.CallbackContext context)
    {
        if (context.started && inputDelayTimer <= 0)
        {
            Vector2 playerLoc = new Vector2(transform.position.x, transform.position.z);
            collider.AddImpulse(impulseStrength, playerLoc);
            collider.SetColliderValues(inputDelay, stats.Strength , colliderDelay);

            anim.SetFloat("AttackSpeed", attackSpeed);
            anim.SetTrigger("attackb");

            OnTurnEnd(false);
        }
    }

    public override void OnSpecial2(InputAction.CallbackContext context)
    {
        if (context.started && inputDelayTimer <= 0)
        {
            OnTurnEnd(false);
        }
    }



}
