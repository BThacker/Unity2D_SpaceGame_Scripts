using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ScrollingScript : MonoBehaviour {

    // How fast we want the background to move
    public Vector2 speedOfPara = new Vector2(0, 2);
    // What direction we want the background to move
    public Vector2 direction = new Vector2(0, -1);
    //Defines whether or not its linked to the camera
    public bool isLinkedtoCamera = false;
    //Should the background be infinite?
    public bool isLooping = false;
    // List of children with a renderer
    private List<Transform> backgroundPart;


	// Use this for initialization
	void Start () {
        // Get all the children
        // For infinite background ONLY
        if (isLooping)
        {
            //Get all the children of the layer with a renderer
            backgroundPart = new List<Transform>();
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                // Add only the visible children
                if(child.renderer != null)
                {
                    backgroundPart.Add(child);
                }
            }

            //Sort by position/ we will get the children from bottom to top
            backgroundPart = backgroundPart.OrderBy(
                t => t.position.y
                ).ToList();
        }
	
	}
	
	// Update is called once per frame
	void Update () {

        // Movement
        Vector3 movement = new Vector3(speedOfPara.x * direction.x, speedOfPara.y * direction.y, 0);

        movement *= Time.deltaTime;
        transform.Translate(movement);

        // Move the camera
        if (isLinkedtoCamera)
        {
            Camera.main.transform.Translate(movement);
        }

        if (isLooping)
        {
            //Get the first object, the list is ordered from bottom to top
            Transform firstChild = backgroundPart.FirstOrDefault();

            if (firstChild != null)
            {
                // Check to see if the child is already before the camera
                if(firstChild.position.y < Camera.main.transform.position.y)
                {
                    // if the child is already under the camera, we test if it's outside and needs to be recycled
                    if(firstChild.renderer.IsVisibleFrom(Camera.main) == false)
                    {
                        //Get the last child position 
                        Transform lastChild = backgroundPart.LastOrDefault();
                        Vector3 lastPosition = lastChild.transform.position;
                        Vector3 lastSize = (lastChild.renderer.bounds.max - lastChild.renderer.bounds.min);

                        //Set the position of the recycled one to be ontop of the last child

                        // this is the code for left to right // firstChild.position = new Vector3(lastPosition.x + lastSize.x, firstChild.position.y, firstChild.position.z);
                        // The below code WORKS!!11 for doing vertical infinite scrolling of an object via a list
                        firstChild.position = new Vector3(lastPosition.x, lastPosition.y + lastSize.y, firstChild.position.z);

                        // Set the recycled child to the last position of the background part list

                        backgroundPart.Remove(firstChild);
                        backgroundPart.Add(firstChild);
                    }
                }
            }
        }
	
	}
}
