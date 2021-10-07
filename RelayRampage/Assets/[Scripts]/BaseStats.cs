using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class BaseStats : MonoBehaviour
{
     public classType typeId {get {return typeId; } }
     public int maxHealth {get {return maxHealth; } }
     public int strength {get {return strength; } }
     public int magic {get {return magic; } }
     public int defence {get {return defence; } }
     public int speed{get {return speed; } }
     public float weight{get {return weight; } }

    public void saveData()
    {
        using (StreamWriter sw = new StreamWriter(Application.dataPath + Path.DirectorySeparatorChar + "PartySaveData.txt"))
        {
            sw.WriteLine(typeId + "," + maxHealth + "," + strength + "," + magic + "," + defence + "," + speed + "," + 1 + "," + 0);
        }
    }
}
