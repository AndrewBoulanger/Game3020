using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KnightAttackBehaviour : PlayerAttackBehaviour
{
    public override void OnBasicAttack(InputAction.CallbackContext context)
    {
        if(context.started)
        { 
            anim.SetTrigger("attackb");
        }
    }

    public override void OnDefend(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            anim.SetFloat("AttackSpeed", attackSpeed);
            anim.SetBool("Defending", true);
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
