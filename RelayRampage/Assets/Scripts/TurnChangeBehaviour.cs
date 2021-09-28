using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

public class TurnChangeBehaviour : MonoBehaviour
{

    List<PlayerMovement> MoveControllers;
    List<PlayerAttackBehaviour> attackControllers;

    int activeCharacter = 0;

    bool activeTurnDelay = false;
    float timer = 0;
    [SerializeField]
    float delayTime = 5f;

    PlayerInput inputs;

    /// <summary>
    /// add players to the turn order. get and disable input components, save them to turn back on later
    /// </summary>
    /// <param name="partyMember"></param>
    public void addPartyCharacter(GameObject partyMember)
    {
        PlayerMovement tempMove = partyMember.GetComponent<PlayerMovement>();
        PlayerAttackBehaviour tempAttack = partyMember.GetComponent<PlayerAttackBehaviour>();
        Assert.IsNotNull(tempMove);
        Assert.IsNotNull(tempAttack);
        tempMove.enabled = false;
        tempAttack.enabled = false;
        MoveControllers.Add(tempMove);
        attackControllers.Add(tempAttack);
        tempAttack.OnTurnEnd += incrementTurn;
    }

    private void Awake()
    {
        MoveControllers = new List<PlayerMovement>();
        attackControllers = new List<PlayerAttackBehaviour>();
        inputs = GetComponent<PlayerInput>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(MoveControllers[ activeCharacter] != null)
        toggleActive(activeCharacter, true);

        //dont start with input enabled to avoid carrying over input when loading
        inputs.enabled = true;
    }

    private void Update()
    {
        
        if(activeTurnDelay)
        {
            timer += Time.deltaTime;
            if(timer >= delayTime)
            {
                timer = 0;
                activeTurnDelay = false;
                toggleActive(activeCharacter, true);
            }
        }
    }

    void incrementTurn(bool withTimer)
    {
        toggleActive(activeCharacter, false);
        activeCharacter++;
        if(activeCharacter >= MoveControllers.Count)
            activeCharacter = 0;

        if(withTimer) //delay next character's
            activeTurnDelay = true;
        else
            toggleActive(activeCharacter, true);
    }
    void toggleActive(int index, bool isActive)
    {
        MoveControllers[index].enabled = isActive;
        attackControllers[index].enabled = isActive;
    }

    //
    //get inputs, pass them to the appropriate character
    //

    public void OnMoveInput(InputAction.CallbackContext context)
    {
       // print(activeCharacter);
        MoveControllers[activeCharacter].setVelocity(context);
    }
    public void OnBasicAttackInput(InputAction.CallbackContext context)
    {
        if(attackControllers[activeCharacter] != null ) 
            attackControllers[activeCharacter].OnBasicAttack(context);
    }

    public void OnDefendInput(InputAction.CallbackContext context)
    {
        attackControllers[activeCharacter].OnDefend(context);
    }

    public void OnSpecial1Input(InputAction.CallbackContext context)
    {
        attackControllers[activeCharacter].OnSpecial1(context);
    }

    public void OnSpecial2Input(InputAction.CallbackContext context)
    {
        attackControllers[activeCharacter].OnSpecial2(context);
    }
}
