using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintball : MonoBehaviour
{
    private Material newMaterial;
    public GameObject carMesh;
    public GameObject paintBall;
    Vector3 positionToSave;

    void Start()
    {
        newMaterial = paintBall.GetComponent<Renderer>().material;
        positionToSave = paintBall.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            carMesh.GetComponent<Renderer>().material = newMaterial;
        }
        else if (other.gameObject.tag == "Hands")
        {
            //enable XR throw mechanic
        }
            
        Destroy(paintBall);
        Instantiate(paintBall, positionToSave, Quaternion.identity);
    }
}
