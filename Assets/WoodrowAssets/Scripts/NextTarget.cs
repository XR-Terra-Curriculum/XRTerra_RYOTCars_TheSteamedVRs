using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTarget : MonoBehaviour
{
    public Transform nextTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SceneryCar")
        {
            other.GetComponent<FollowPoint>().target = nextTarget;
        }
    }
}
