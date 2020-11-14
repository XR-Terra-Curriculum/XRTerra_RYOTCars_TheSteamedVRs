using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Teleportation : MonoBehaviour
{
    public GameObject teleportArea;
    public GameObject teleportAnchor;
    public GameObject teleportRay;
    

    // Start is called before the first frame update
    void Start()
    {
        teleportArea.gameObject.SetActive(false);
        teleportAnchor.gameObject.SetActive(false);
        teleportRay.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*bool TeleportActive()
    {
        if (Input.GetKey)
    }*/
}
