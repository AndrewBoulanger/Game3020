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
            Debug.Log("attacked");
        }
    }

    public override void OnDefend(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("defend");
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
