using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class GameManager : MonoBehaviour {
   
    private GameObject spawnPoint;
    public GameObject player;
 
    public static GameManager instance = null;  
    public bool PlayerIsAlive;

    public int Score { get { return score; } set { score = value; } }
    
    private int score;
	// Use this for initialization
	void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        
        spawnPoint = GameObject.Find("PlayerSpawn");
        PlayerIsAlive = false;      
	}
	// Update is called once per frame
	void Update () 
    {      
	}
    public void StartGame()
    {
        score = 0;
        MenuManager.instance.UpdateScore();
        SpawnPlayer();      
        PlayerIsAlive = true;
        AIManager.instance.AIActivated = true;
        MenuManager.instance.HideMainMenu();
        MenuManager.instance.ShowGui();
    }
    public void RestartGame()
    {
        score = 0;
        MenuManager.instance.UpdateScore();
        Invoke("SpawnPlayer", 1.5F);
        PlayerIsAlive = true;
        AIManager.instance.AIActivated = true;
        MenuManager.instance.ShowGui();
    }
    public void PlayerDied()
    {
        AIManager.instance.AIActivated = false;
        MenuManager.instance.ShowGameOverMenu();
        Debug.Log("Player got killed, yo");
    }

    public void SpawnPlayer()
    {
        GameObject.Instantiate(player, spawnPoint.transform.position, Quaternion.identity);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////
    // Below are methods and class for saving data to the generic location, This works on PC and Mobile
    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saveData.dat");
        PlayerData data = new PlayerData();
        // Variables go here 
        
        bf.Serialize(file, data);
        // Always close the file to prevent lock
        file.Close();
    }
    public void LoadData()
    {
        if(File.Exists(Application.persistentDataPath + "/saveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveData.dat", FileMode.Open);
            //PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
        }
    }
}
[Serializable]
class PlayerData
{
    // here we store the variables we would like to write to a file
    public int LastScore;
    public int HighScore;
    public int TotalGamesPlayed;
    public int TotalTimesWon;
}
