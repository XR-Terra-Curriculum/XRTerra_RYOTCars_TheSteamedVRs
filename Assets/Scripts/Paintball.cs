using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintball : MonoBehaviour
{
    public Material newMaterial;
    public GameObject carMesh;
    public GameObject paintBall;
    public Vector3 positionToSave;

    void Start()
    {
        newMaterial = paintBall.GetComponent<Renderer>().material;
        positionToSave = paintBall.transform.position;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Teleportation")
        {
            /*
            Destroy(gameObject);
            Instantiate(paintBall, positionToSave, Quaternion.identity);
            */
            gameObject.transform.position = positionToSave;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
        }
    }
}
