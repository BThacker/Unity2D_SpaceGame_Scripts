using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIManager : MonoBehaviour 

{    
    public static AIManager instance = null;
    public List<GameObject> ObjectsAlive = new List<GameObject>();

    private bool aiActivated;
    public bool AIActivated { get { return aiActivated; } set { aiActivated = value; } }

    public float SpawnGravityScale;
    public float DifficultyGravityScale;
    private bool isPlayerAlive;
    private int gameScore;

    void Awake()
    {
        SpawnGravityScale = 0.05F;
        DifficultyGravityScale = 0.5F;
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);      
    }  
    void Update()
    {
        gameScore = GameManager.instance.Score;
        isPlayerAlive = GameManager.instance.PlayerIsAlive;
        //If AI should be ran 
       if (aiActivated && isPlayerAlive)
       {
           // Disable for testing
          /* if (gameScore <= 3)
           {
               DifficultyGravityScale = .5f;
               ObjectSpawner.instance.SpawnItem(1, false);
               Debug.Log("Spawning Phase 1");
           }
           if (gameScore >= 4 && gameScore <= 10)
           {
               DifficultyGravityScale = .65F;
               ObjectSpawner.instance.SpawnItem(2, false);
               Debug.Log("Spawning Phase 2");
           }
           if (gameScore >= 11 && gameScore <= 75)
           {
               DifficultyGravityScale = .8F;
               ObjectSpawner.instance.SpawnItem(3, false);
               Debug.Log("Spawning Phase 3");
           }
           * */

           if (gameScore <= 25)
           {
               ObjectSpawner.instance.SpawnObstacle(2,4);
           }
           
       }
       
    }


 
}
