using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScoreAndKillScript : MonoBehaviour {


    
    public Text ScoreText;
	// Update is called once per frame

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Increment GameManager tracking of score, call to method to update score
        if (GameManager.instance.PlayerIsAlive)
        {
            GameManager.instance.Score++;
            MenuManager.instance.UpdateScore();
        }
        // Here we check to see if the other object is tagged as an enemy item
        // If so, we destroy that game object to prevent memory leaks
        // Remember to tag objects with EnemyTag
        if (col.gameObject.tag == "EnemyItem")
            Destroy(col.gameObject);

        else
            Debug.Log("I have nothing to do with the remaining items that are getting up in me");
    }
}
