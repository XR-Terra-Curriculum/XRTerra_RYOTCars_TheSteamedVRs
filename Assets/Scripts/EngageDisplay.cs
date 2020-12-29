using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngageDisplay : MonoBehaviour
{

    private MeshRenderer[] carBody;
    private GameObject lastCar = null;//for storing the last car to be displayed

    private Material[] newPaint;
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
        //Debug.Log(other.tag);
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
            carBody = lastCar.GetComponentsInChildren<MeshRenderer>();
            foreach(MeshRenderer carBodyPart in carBody)
            {
                if (carBodyPart.gameObject.tag == "Car Body")
                {
                    newPaint = new Material[carBodyPart.materials.Length];
                    for (int i = 0; i < carBodyPart.materials.Length; i++)
                    {
                        //Debug.Log("I = " + i + ", carBodyPart = " + carBodyPart.ToString());
                        if (carBodyPart.gameObject.GetComponent<PaintList>().partList[i])
                        {
                            newPaint[i] = other.gameObject.GetComponent<Paintball>().newMaterial;
                        }
                        else
                        {
                            if(carBodyPart.materials[i]!=null)
                                newPaint[i] = carBodyPart.materials[i];
                        }
                    }

                    carBodyPart.materials = newPaint;
                }
            }
            other.transform.position = other.GetComponent<Paintball>().positionToSave;
           other.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        }

    }
}
