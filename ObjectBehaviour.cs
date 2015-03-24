using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectBehaviour : MonoBehaviour {
    // Here, after the object is spawned we set the gravity scale to a low amount
    // so the player can see the object that is spawned and plan accordingly
    // then after a set amount of time, we drop the object on the player


	
	void Awake () {

        AIManager.instance.ObjectsAlive.Add(gameObject);

        rigidbody2D.gravityScale = AIManager.instance.SpawnGravityScale;
        Invoke("DropTheHammer", 1.9f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Here we will detect that the object has entered the score zone, and remove it
    // from the game to prevent memory leaks
    void DropTheHammer()
    {
        Debug.Log("TheInvokeFunctionIsWorking");
        rigidbody2D.gravityScale = AIManager.instance.DifficultyGravityScale;
    }

    void OnDestroy()
    {
        AIManager.instance.ObjectsAlive.Remove(gameObject);
    }

}
