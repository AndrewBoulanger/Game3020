using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public delegate void TurnOverDelegate(bool isDead);
public abstract class PlayerAttackBehaviour : MonoBehaviour
{
    public TurnOverDelegate OnTurnEnd;
    bool isDead = false;

    TurnIndicatorEffects turnIndicatorCylinder;
    // Start is called before the first frame update
    void Awake()
    {
       turnIndicatorCylinder = GetComponentInChildren<TurnIndicatorEffects>();
    }

    // Update is called once per frame
    void Update()
    {

        //if at any point the player is dead, end their turn immediately
        if(isDead)
            OnTurnEnd(true);
    }

    private void OnEnable()
    {
        if( turnIndicatorCylinder != null)
            turnIndicatorCylinder.gameObject.SetActive(true);
        else
            print("cylinder not found");
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
