using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public string tagToDestroy = "obstacle";
    public GameObject Perso;
    void onTriggerEnter(Collider other){
        if (other.gameObject == Perso){
            GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(tagToDestroy);
            foreach (GameObject obj in objectsToDestroy)
            {
                Destroy(obj);
            }

            Destroy(gameObject);
        }
    }
}
