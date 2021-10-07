using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PartyManager : MonoBehaviour
{
    public static PartyManager _instance;
    public static PartyManager Instance
    {
        get
        {
            if (_instance == null)
            { 
                _instance = GameObject.FindObjectOfType<PartyManager>();
                DontDestroyOnLoad(_instance.gameObject);
                if(_instance == null)
                {
                    GameObject container = new GameObject("party manager");
                    _instance = container.AddComponent<PartyManager>();
                    DontDestroyOnLoad(container);
                }
            }
            
            return _instance;
        }
    }

    public List<CharacterStats> party;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
