using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnHome : MonoBehaviour
{
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
            other.GetComponent<FollowPoint>().enabled = true;
            other.transform.localScale = new Vector3(1,1,1);
            other.GetComponent<FollowPoint>().SendHome();
        }

        if(other.tag == "Paintball")
        {
            other.GetComponent<Paintball>().reposition();
        }



    }
}
