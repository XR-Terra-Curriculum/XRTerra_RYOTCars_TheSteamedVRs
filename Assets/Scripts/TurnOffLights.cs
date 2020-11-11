using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffLights : MonoBehaviour
{
    //these variables are for altering joints per frame because scaling causes issues
    private Transform[] children;
    // Start is called before the first frame update
    void Start()
    {
        //turn off all car lights on start, they will enable with size change
        children = transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i].GetComponent<Light>() != null)
            {
                children[i].GetComponent<Light>().enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
