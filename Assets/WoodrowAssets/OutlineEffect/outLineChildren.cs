using System.Collections;
using System.Collections.Generic;
using cakeslice;
using UnityEngine;
using Valve.VR;

public class outLineChildren : MonoBehaviour
{
    private Outline[] allChildren;
    // Start is called before the first frame update
    void Start()
    {
        allChildren = GetComponentsInChildren<Outline>();
        hideLines();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayLines()
    {
        foreach (Outline child in allChildren)
        {
            child.enabled = true;
        }
    }

    public void hideLines()
    {
        foreach (Outline child in allChildren)
        {
            child.enabled = false;
        }
    }
}
