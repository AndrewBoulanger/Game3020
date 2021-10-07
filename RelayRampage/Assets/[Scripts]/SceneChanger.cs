using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneChanger : MonoBehaviour
{

    public void loadSelectScene()
    {
        SceneManager.LoadScene(1);
    }
}
