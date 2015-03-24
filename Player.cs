using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private bool movingLeft = true;
    private bool movementStarted = false;
    public int LeftAccel = -50;
    public int RightAccel = 50;
    private bool playerIsAlive;
    
	void Awake () {
        
        
	}
	void Update () {

        playerIsAlive = GameManager.instance.PlayerIsAlive;
        // Make sure we are not outside the camera bounds left and right 
        // Not going to use right now 
        /*
        if (playerIsAlive)
        {


            var dist = (transform.position - Camera.main.transform.position).z;

            var leftBorder = Camera.main.ViewportToWorldPoint(
                new Vector3(0, 0, dist)
                ).x;

            var rightBorder = Camera.main.ViewportToWorldPoint(
                new Vector3(1, 0, dist)
                ).x;

            var topBorder = Camera.main.ViewportToWorldPoint(
                new Vector3(0, 0, dist)
                ).y;

            var bottomBorder = Camera.main.ViewportToWorldPoint(
                new Vector3(0, 1, dist)
                ).y;

            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
                Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
                transform.position.z);
        // Not going to use this right now 
        }
        */
        // Check to see if the game manager is allowing input, then control similar to Swing Copters
        
        if (playerIsAlive && Input.GetKeyDown(KeyCode.B) && movingLeft)
        {
            MoveRight();
            movingLeft = false;
            movementStarted = true;
        }
        else if (playerIsAlive && Input.GetKeyDown(KeyCode.B))
        {
            MoveLeft();
            movingLeft = true;
        }
        
	}
    void FixedUpdate()
    {
        // Once movement is triggered we add a constant force to simulate acceleration and give a 
        // smooth feel to the players movement and direction changes
        if (movementStarted)
        {
            if (movingLeft)
                rigidbody2D.AddForce(new Vector2(LeftAccel, 0));
            

            if (!movingLeft)
                rigidbody2D.AddForce(new Vector2(RightAccel, 0));
            
        }
    }
    // Here we will handle what we want the player to do when it collides with another object.
    void OnCollisionEnter2D(Collision2D collision)
    {
        // This activates gravity for the object to simulate a reaction to being hit
        rigidbody2D.gravityScale = 1;
        Invoke("DestroyOnDeath", 2.0F);
        GameManager.instance.PlayerIsAlive = false;
        
    }
    void MoveLeft()
    {
        // Immediately halt all force, and change direction
        rigidbody2D.velocity = new Vector2(-1, 0);
        
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 10));
        
        
    }
    void MoveRight()
    {
        // Immediately halt all force, and change direction 
        rigidbody2D.velocity = new Vector2(1, 0);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -10));
       
    }

    void Flip()
    {
        
    }
    void DestroyOnDeath()
    {
        // Destroy the object and invoke the method on the game manager
        Destroy(gameObject);
        GameManager.instance.PlayerDied();
    }
}
