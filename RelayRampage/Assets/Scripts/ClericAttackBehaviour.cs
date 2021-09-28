using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClericAttackBehaviour : PlayerAttackBehaviour
{
    public override void OnBasicAttack(InputAction.CallbackContext context)
    {
        if(context.started && inputDelayTimer <= 0)
        {
            inputDelayTimer = inputDelay;
            anim.SetFloat("AttackSpeed", attackSpeed);
            anim.SetTrigger("Attack");
        }
    }

    public override void OnDefend(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            defending = true;
            anim.SetBool("Defending", true);
            //enable shield object when added
            OnTurnEnd(false);
            
        }
    }

    public override void OnSpecial1(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnTurnEnd(false);
        }
    }

    public override void OnSpecial2(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnTurnEnd(false);
        }
    }


}
