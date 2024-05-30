using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BasicPlayerController : MonoBehaviour
{

    float speed = 10f;

    void Start()
    {
        
    }
 
    void Update()
    {

        // What is the player doing with the controls?
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"),
			Input.GetAxis("Vertical"), 0);
 
		// Update the ships position each frame
		transform.position += move
			* speed * Time.deltaTime;

    }
}