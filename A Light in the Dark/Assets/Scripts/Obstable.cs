using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstable : MonoBehaviour
{

    public GameObject obstacle;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (
            other.gameObject.tag == "Player" && 
            other.gameObject.GetComponent<Platformer.Mechanics.BasicPlayerController>().lightPoints > 0 &&
            Input.GetKeyDown(KeyCode.F)
        )
        {
            Debug.Log("Player collided with obstacle");
            Destroy(obstacle);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (
            other.gameObject.tag == "Player" && 
            other.gameObject.GetComponent<Platformer.Mechanics.BasicPlayerController>().lightPoints > 0 &&
            Input.GetKeyDown(KeyCode.F)
        )
        {
            Debug.Log("Player is in range");
            Destroy(obstacle);
        }
    }
}
