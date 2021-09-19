using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CharacterChoiceOptions : MonoBehaviour
{
    [SerializeField]
    Image[] frames;
    [SerializeField]
    Sprite off_Frame;
    [SerializeField]
    Sprite on_Frame;

    int classTypes = 4;
    int selectIndex = 0;


    public void ChangeIndex(InputAction.CallbackContext context)
    {
        if(context.started)
        { 
        frames[selectIndex].sprite = off_Frame;

        //move index to a new frame in the array, clamp within allowable values
        selectIndex = (context.ReadValue<Vector2>().x > 0) ? selectIndex + 1 : selectIndex -1;
        if(selectIndex > classTypes-1)
            selectIndex = classTypes-1;
        if(selectIndex < 0)
            selectIndex = 0;

        frames[selectIndex].sprite = on_Frame;
        }
    }

    public void Enter()
    {
        Debug.Log("enter");
        
    }
    public void Back()
    {
        Debug.Log("back");
    }
}
