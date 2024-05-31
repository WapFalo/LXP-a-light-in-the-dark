using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPoint : MonoBehaviour
{

    public GameObject lightPoint;
    public float lightPointRadius = 5f;
    public float lightIntensity = 0.5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player collided with light point");
            lightPoint.SetActive(false);
            other.gameObject.GetComponent<Platformer.Mechanics.BasicPlayerController>().lightPoints++;
            other.gameObject.GetComponent<Platformer.Mechanics.BasicPlayerController>().light.pointLightOuterRadius += lightPointRadius;
            other.gameObject.GetComponent<Platformer.Mechanics.BasicPlayerController>().light.intensity += lightIntensity;
        }
    }
}
