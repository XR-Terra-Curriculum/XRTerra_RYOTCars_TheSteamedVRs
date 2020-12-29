using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePaint : MonoBehaviour
{

    public GameObject paintBalls;
    public GameObject oldPaintBalls;
    // Start is called before the first frame update
    void Start()
    {
        paintBalls.SetActive(false);
        oldPaintBalls.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car")
        {
            paintBalls.SetActive(false);
            oldPaintBalls.SetActive(false);
        }
    }
}
