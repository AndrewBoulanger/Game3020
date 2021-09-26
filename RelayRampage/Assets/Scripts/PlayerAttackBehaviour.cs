using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public delegate void TurnOverDelegate(bool isDead);
public abstract class PlayerAttackBehaviour : MonoBehaviour
{
    public TurnOverDelegate OnTurnEnd;
    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //if at any point the player is dead, end their turn immediately
        if(isDead)
            OnTurnEnd(true);
    }

    public abstract void OnBasicAttack(InputAction.CallbackContext context);
    public abstract void OnDefend(InputAction.CallbackContext context);
    public abstract void OnSpecial1(InputAction.CallbackContext context);
    public abstract void OnSpecial2(InputAction.CallbackContext context);
}
