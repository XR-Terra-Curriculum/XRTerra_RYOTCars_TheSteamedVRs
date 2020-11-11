using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidHome : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //when a car reaches the home, turn it back into a rigidbody
    void OnTriggerStay(Collider other)
    {

        if (other.tag == "Car")
        {
            if (other.GetComponent<FollowPoint>().home == gameObject.transform)
            {
                other.GetComponent<FollowPoint>().enabled = false;
            }
        }
    }
}
