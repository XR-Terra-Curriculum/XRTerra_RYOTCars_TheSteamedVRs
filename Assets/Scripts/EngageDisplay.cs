﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngageDisplay : MonoBehaviour
{

    private GameObject lastCar = null;//for storing the last car to be displayed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //if the object is a car and not currently following a point, turn on followpoint towards the display area
        if (other.tag == "Car" && other.GetComponent<FollowPoint>().enabled == false)
        {
            other.GetComponent<Collider>().enabled = false;
            other.GetComponent<FollowPoint>().enabled = true;
            other.GetComponent<FollowPoint>().SendDisplay();

            //if there was a previous car displayed, send it home
            if (lastCar != null)
            {
                lastCar.GetComponent<FollowPoint>().SendHome();
            }

            //store display car as new previous car
            lastCar = other.gameObject;
        }

    }
}