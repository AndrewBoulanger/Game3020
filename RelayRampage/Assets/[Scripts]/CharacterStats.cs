using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public enum classType
{
    knight, mage, cleric, thief
}
public class CharacterStats : MonoBehaviour
{
    [SerializeField] classType typeId;
    int health;
    [SerializeField] int maxHealth;
    [SerializeField] int strength;
    [SerializeField] int magic;
    [SerializeField] int defence;
    [SerializeField] int speed = 10;
    [SerializeField] float weight;
    int level = 1;
    int exp;

    public classType TypeId{get {return typeId;}}
    public int Strength {get { return strength; } }
    public int Magic {get { return magic; } }
    public int Defence {get { return defence; } }
    public int Speed {get { return speed; } }
    public int Weight {get { return Weight; } }
    
    public void SaveCharacterStats()
    {

    }
    public void LoadCharacterStats()
    {

    }

    public void ReduceHealth(int damage)
    {

    }

    public void AddExp(int xp)
    {

    }
    void levelUp()
    {

    }

    public void saveData(StreamWriter sw)
    {
        if(sw != null)
        { 
            sw.WriteLine(((int)typeId) + "," + maxHealth + "," + strength + "," + magic + "," + defence + "," + speed + "," + level + "," + exp);
        }
    }

    /// <summary>
    /// pass in saved data from the party save data file. each line will be one character, so call once per character/line
    /// this function will separate the values and assign them to the character stats
    /// </summary>
    /// <param name="line"></param>
    public void LoadCharacter(string line)
    {
        string[] LineIn = line.Split(',');

    //see saveData function above for array order, i don't fully like this, but its simple
    //note: we can skip typeId, as that will never change
        maxHealth = int.Parse(LineIn[1]);
        health = maxHealth;
        strength = int.Parse(LineIn[2]);
        magic = int.Parse(LineIn[3]);
        defence = int.Parse(LineIn[4]);
        speed = int.Parse(LineIn[5]);
        level = int.Parse(LineIn[6]);
        exp = int.Parse(LineIn[7]);
    }
}
