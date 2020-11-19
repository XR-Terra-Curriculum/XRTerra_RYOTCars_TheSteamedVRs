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

        Debug.Log(other.tag);
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
            //Debug.Log("Is paint ball!");
            carBody = lastCar.GetComponentsInChildren<MeshRenderer>();
            foreach(MeshRenderer carBodyPart in carBody)
            {
               //Debug.Log("meshrenderer in list");
                if (carBodyPart.gameObject.tag == "Car Body")
                {
                    //Debug.Log("Tag is carbody, applying material " + other.gameObject.GetComponent<Paintball>().newMaterial);
                    //carBodyPart.material = other.gameObject.GetComponent<Paintball>().newMaterial;
                    newPaint = new Material[100];
                    for (int i = 0; i < carBodyPart.materials.Length; i++)
                    {
                        //Debug.Log("count a material!");
                        //carBodyPart.materials[i] = other.gameObject.GetComponent<Paintball>().newMaterial;
                        newPaint[i] = other.gameObject.GetComponent<Paintball>().newMaterial;
                    }

                    carBodyPart.materials = newPaint;
                }
            }
            /*
            Destroy(other.gameObject);
            Instantiate(other.gameObject, other.gameObject.GetComponent<Paintball>().positionToSave, Quaternion.identity);
            */
           other.transform.position = other.GetComponent<Paintball>().positionToSave;
           other.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        }

    }
}
