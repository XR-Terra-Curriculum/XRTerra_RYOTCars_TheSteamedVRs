using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngageDisplay : MonoBehaviour
{

    private Renderer[] carBody;
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
            foreach (Collider box in other.GetComponentsInChildren<Collider>())
            {
                box.enabled = true;
            }
            other.GetComponent<FollowPoint>().enabled = true;
            other.GetComponent<FollowPoint>().SendDisplay();

         

            //if there was a previous car displayed, send it home
            if (lastCar != null)
            {
                lastCar.GetComponent<FollowPoint>().SendHome();
            }

            //store display car as new previous car
            lastCar = other.gameObject;

            GetComponent<AudioSource>().clip = other.GetComponent<CarSounds>().engineStart;
            GetComponent<AudioSource>().Play();
            other.GetComponent<CarSounds>().playEngine();
            
        }
        else if (other.tag == "Paintball")
        {
            carBody = lastCar.GetComponentsInChildren<Renderer>();
            foreach(Renderer carBody in other.GetComponentsInChildren<Renderer>())
            {
                if (carBody.tag == "Car Body")
                {
                    carBody.material = other.gameObject.GetComponent<Paintball>().newMaterial;
                }
            }
            Destroy(other.gameObject);
            Instantiate(other.gameObject, other.gameObject.GetComponent<Paintball>().positionToSave, Quaternion.identity);
        }

    }
}
