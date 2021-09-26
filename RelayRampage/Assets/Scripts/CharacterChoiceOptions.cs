using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;


public class CharacterChoiceOptions : MonoBehaviour
{
    [SerializeField]
    Image[] frames;
    [SerializeField]
    Sprite off_Frame;
    [SerializeField]
    Sprite on_Frame;
    [SerializeField]
    TextMeshProUGUI[] stats;
    [SerializeField]
    ObjectPool[] characterOptions;

    [SerializeField]
    Transform[] chosenSlots;
    GameObject[] chosenCharacters;


    const int classTypes = 4;
    int selectIndex = 0;
    const int OpenSlots = 3;
    int chosenIndex = 0;

    public ConfirmWindowDelegate confirmDelegate;

    [SerializeField]
    ConfirmWindow confirmWindow;

    private void Start()
    {
        chosenCharacters = new GameObject[3];

        confirmDelegate = ConfirmParty;
    }

    public void ChangeIndex(InputAction.CallbackContext context)
    {
        if(context.started)
        { 
            frames[selectIndex].sprite = off_Frame;
            stats[selectIndex].enabled = false;

            //move index to a new frame in the array, clamp within allowable values
             selectIndex = (context.ReadValue<Vector2>().x > 0) ? selectIndex + 1 : selectIndex -1;
            if(selectIndex > classTypes-1)
                selectIndex = classTypes-1;
             if(selectIndex < 0)
                selectIndex = 0;

            frames[selectIndex].sprite = on_Frame;
            stats[selectIndex].enabled = true;
        }
    }

    /// <summary>
    /// /select a character and add it to the chosenCharacters list from the corresponding object pool
    /// if three characters have been chosen enable a window to confirm character choices
    /// </summary>
    //
    public void Enter(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            GameObject character = characterOptions[selectIndex].GetPooledObject();
            if (character != null)
            {
                chosenCharacters[chosenIndex] = character;
                chosenCharacters[chosenIndex].SetActive(true);
                chosenCharacters[chosenIndex].transform.position = chosenSlots[chosenIndex].transform.position;
                 chosenCharacters[chosenIndex].transform.rotation = chosenSlots[chosenIndex].transform.rotation;
                chosenIndex++;

                if (chosenIndex >= OpenSlots && confirmWindow != null)
                {
                    GetComponent<PlayerInput>().enabled = false;
                  
                    confirmWindow.gameObject.SetActive(true);
                    confirmWindow.EnableWindow(gameObject, confirmDelegate);
                }
            }
            else
                Debug.Log("pool did not return valid character");
        }
    }
    public void Back(InputAction.CallbackContext context)
    {
        if(context.started)
            Back();
    }

    public void ConfirmParty( bool confirmed)
    {
        if(confirmed)
        {
           using (StreamWriter sw = new StreamWriter(Application.dataPath + Path.DirectorySeparatorChar + "PartySaveData.txt"))
            foreach(GameObject partyMember in chosenCharacters)
            {
              partyMember.GetComponent<CharacterStats>().saveData(sw);
            }
           
            SceneManager.LoadScene("BattleScene");
        }
        else
            Back();
    }

    public void Back()
    {
        if (chosenIndex <= 0)
            return;

        chosenIndex--;
        chosenCharacters[chosenIndex].SetActive(false);
        chosenCharacters[chosenIndex] = null;

       GetComponent<PlayerInput>().enabled = true;;
    }

}
