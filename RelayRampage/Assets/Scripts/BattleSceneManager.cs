using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Assertions;

public class BattleSceneManager : MonoBehaviour
{
   [SerializeField]GameObject[] partyPrefabs;

    [SerializeField]List<Transform> playerSpawnPoints;
    [SerializeField]List<Transform> enemySpawnPoints;
    [SerializeField]List<Transform> treasureSpawnPoints;

    TurnChangeBehaviour TurnController;

    string saveDataPath;
    private void Awake()
    {
        TurnController = FindObjectOfType<TurnChangeBehaviour>();
        Assert.IsNotNull(TurnController, "the turn controller could not be found");

        saveDataPath = Application.dataPath + Path.DirectorySeparatorChar + "PartySaveData.txt";
        LoadParty();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// loads the party into the battle scene using data stored in PartySavedData.txt
    /// places party members in the scene's spawn points and adds them to the turn controller.
    /// </summary>
    private void LoadParty()
    {
        string line = "";
        using (StreamReader sr = new StreamReader(saveDataPath))
        {
            while ((line = sr.ReadLine()) != null)
            {
                int characterType = int.Parse(line.Substring(0, 1));
                GameObject partyMember = Instantiate(partyPrefabs[characterType]);
                CharacterStats stats;
                if (partyMember != null && (stats = partyMember.GetComponent<CharacterStats>()) != null)
                {
                    stats.LoadCharacter(line);
                }
                partyMember.transform.position = playerSpawnPoints[0].position;
                partyMember.transform.rotation = playerSpawnPoints[0].rotation;
                TurnController.addPartyCharacter(partyMember);
                playerSpawnPoints.RemoveAt(0);
            }
        }
    }
}
