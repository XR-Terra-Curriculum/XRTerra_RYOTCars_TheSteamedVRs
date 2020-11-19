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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Teleporation")
        {
            Destroy(paintBall);
            Instantiate(paintBall, positionToSave, Quaternion.identity);
        }
    }
}
