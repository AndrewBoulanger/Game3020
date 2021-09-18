using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum ControllerMode
{
    keyboard, gamePad
}

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
    bool hasInput = false;

    [SerializeField]
    ControllerMode controller;
    string horizontal;
    string enter;
    string back;

    // Start is called before the first frame update
    void Start()
    {
        horizontal = controller == ControllerMode.keyboard ? "Horizontal" : "Horizontal_con";
         enter = controller == ControllerMode.keyboard ? "Select" : "Select_con";
         back = controller == ControllerMode.keyboard ? "Back" : "Back_con";
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputVal = Input.GetAxis(horizontal);

        if(hasInput == false && inputVal != 0)
        {
            hasInput = true;
            ChangeIndex(inputVal);
        }
        if( inputVal == 0)
        {
            hasInput = false;
        }




        if (Input.GetButtonDown(enter))
        {
            Enter();
        }
        if (Input.GetButtonDown(back))
        {
            Back();
        }

    }


    void ChangeIndex(float val)
    {
        frames[selectIndex].sprite = off_Frame;

        //move index to a new frame in the array, clamp within allowable values
        selectIndex = (val > 0) ? selectIndex + 1 : selectIndex -1;
        if(selectIndex > classTypes-1)
            selectIndex = classTypes-1;
        if(selectIndex < 0)
            selectIndex = 0;

        frames[selectIndex].sprite = on_Frame;
    }

    private void Enter()
    {
        Debug.Log("enter");
    }
    private void Back()
    {
        Debug.Log("back");
    }
}
