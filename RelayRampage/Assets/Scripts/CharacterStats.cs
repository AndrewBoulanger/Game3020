using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum classType
{
    knight, mage, cleric, thief
}
public class CharacterStats : MonoBehaviour
{
    classType typeId;
    int health;
    int maxHealth;
    int strength;
    int defence;
    int speed = 10;
    float weight;


    public int Speed {get { return speed; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
