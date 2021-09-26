using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BattleSceneManager : MonoBehaviour
{
   [SerializeField]GameObject[] partyPrefabs;

    [SerializeField]List<Transform> playerSpawnPoints;
    [SerializeField]List<Transform> enemySpawnPoints;
    [SerializeField]List<Transform> treasureSpawnPoints;

    string saveDataPath;
    private void Awake()
    {
        saveDataPath = Application.dataPath + Path.DirectorySeparatorChar + "PartySaveData.txt";
        string line = "";
        using (StreamReader sr = new StreamReader(saveDataPath ))
        {
            while ((line = sr.ReadLine()) != null )
            {
                int characterType = int.Parse(line.Substring(0,1));
               GameObject partyMember =  Instantiate(partyPrefabs[characterType]); 
                CharacterStats stats; 
                if(partyMember != null && (stats = partyMember.GetComponent<CharacterStats>()) != null)
                {
                    stats.LoadCharacter(line);
                }
                partyMember.transform.position = playerSpawnPoints[0].position;
                partyMember.transform.rotation = playerSpawnPoints[0].rotation;
                playerSpawnPoints.RemoveAt(0);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
