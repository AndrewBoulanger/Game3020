using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum classType
{
    knight, blackMage, whitemage, thief
}
public class PartyCharacter : MonoBehaviour
{
    classType typeId;
    int health;
    int maxHealth;
    int strength;
    int defence;
    int speed;
    float weight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
