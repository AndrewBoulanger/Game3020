using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public delegate void ConfirmWindowDelegate(bool confirm);

public class ConfirmWindow : MonoBehaviour
{
    public PlayerInput ownerInput;
    public bool pauseWorld = false;
    ConfirmWindowDelegate methodToCall;

    [SerializeField]
    public Image[] UI_options;
    [SerializeField]
    Material Highlighted;
    [SerializeField]
    Material non_Highlighted;

    bool isConfirmHighlighted;


    /// <summary>
    /// opens window with confirm or cancel options. if owner has input it will be suspended till a choice is made
    /// takes a delegate which will eventually be passed an input by the player input,
    /// given the option of pausing the game
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="confirm"></param>
    /// <param name="cancel"></param>
    /// <param name="pauseWorld"></param>
    public void EnableWindow(GameObject owner, ConfirmWindowDelegate confirm, bool pauseWorld = false)
    { 
        //PlayerInput playerInput = owner.GetComponent<PlayerInput>();
        //if(playerInput != null)
        //{
        //    ownerInput = playerInput;
        //    //ownerInput.actions.Disable();
            
        //}
        methodToCall = confirm;
        if(pauseWorld)
            SetWorldPause(true);
        Toggle();
        GetComponent<PlayerInput>().actions.Enable();
        Debug.Log(GetComponent<PlayerInput>().actions.controlSchemes);
    }

    /// <summary>
    /// pause/resume the game as the window appears. called, if specified, when opening or closing the window
    /// </summary>
    /// <param name="pauseWorld"></param> true sets the timescale to 0, false to 1
    private void SetWorldPause(bool pauseWorld)
    {
        this.pauseWorld = pauseWorld;
        Time.timeScale = (pauseWorld)  ? 0:1; 
    }
    private void closeWindow()
    {
        if(pauseWorld)
            SetWorldPause(false);

        gameObject.SetActive(false);
    }
    public void Confirm(InputAction.CallbackContext context)
    {
        if(context.started)
        { 
            GetComponent<PlayerInput>().enabled = false;
            methodToCall(isConfirmHighlighted);
            closeWindow();
        }
    }

    public void Cancel(InputAction.CallbackContext context)
    {
        if(context.started)
        { 
            GetComponent<PlayerInput>().enabled = false;
            methodToCall(false);
            closeWindow();
        }
    }

    public void Toggle(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        UI_options[isConfirmHighlighted.GetHashCode()].material = non_Highlighted;
        isConfirmHighlighted = !isConfirmHighlighted;
        UI_options[isConfirmHighlighted.GetHashCode()].material = Highlighted;
    }
}
