using UnityEngine;
using System.Collections;


public class ObjectSpawner : MonoBehaviour {


    bool isSpawning = false;

    public GameObject[] Obstacles;


    private Vector3[] SpawnLocations = new Vector3[6];
    private Vector3[] obSL = new Vector3[3];
    public GameObject[] Phase1Items;

    public static ObjectSpawner instance = null;

	void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        // Get the marker locations of our defined spawn positions
        SpawnLocations[0] = GameObject.Find("SL1").transform.position;
        SpawnLocations[1] = GameObject.Find("SL2").transform.position;
        SpawnLocations[2] = GameObject.Find("SL3").transform.position;
        SpawnLocations[3] = GameObject.Find("SL4").transform.position;
        SpawnLocations[4] = GameObject.Find("SL5").transform.position;
        SpawnLocations[5] = GameObject.Find("SL6").transform.position;

        obSL[0]= GameObject.Find("ObSL1").transform.position;
        obSL[1] = GameObject.Find("ObSL2").transform.position;
        obSL[2] = GameObject.Find("ObSL3").transform.position;

        
	}
    public void SpawnItem(int numberOfItemsToSpawn, bool SecondWave)
    {
        //Below code sets the item to be level with the orientation of the world
        // GameObject.Instantiate(Phase1Items[0], SpawnLocations[Random.Range(0, SpawnLocations.Length)], Quaternion.identity);
        
        //Below will rotate the item randomly based on what we want
        // Quaternion.Euler(0.0, 0.0, Random.Range(0.0, 360.0)
        for (int i = 0; i < numberOfItemsToSpawn; i++)
        {
        GameObject.Instantiate(Phase1Items[Random.Range(0, 3)], SpawnLocations[Random.Range(0, SpawnLocations.Length)], Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f))); 
            if(SecondWave)
            {
                    Invoke("SpawnItem2", 2F);
            }
        }
    }
    public void SpawnItem2()
    {
            GameObject.Instantiate(Phase1Items[Random.Range(0, 3)], SpawnLocations[Random.Range(0, SpawnLocations.Length)], Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));         
    }
    
    
    public void SpawnObstacle(float minTime, float maxTime)
    {
                //GameObject.Instantiate(Obstacles[0], obSL[Random.Range(0, obSL.Length)], Quaternion.identity); 
        //The below CoRoutine works like we want it to 
        if(!isSpawning)
        {
            isSpawning = true;
            StartCoroutine(SpawnObstacle(Random.Range(minTime,maxTime)));
        }

    }

    IEnumerator SpawnObstacle(float seconds)
    {
        Debug.Log("waiting for x seconds)");
        GameObject.Instantiate(Obstacles[0], obSL[Random.Range(0, obSL.Length)], Quaternion.identity);
        yield return new WaitForSeconds(seconds);

        // We've spawned, so now we can flag false
        isSpawning = false;
    }
}
