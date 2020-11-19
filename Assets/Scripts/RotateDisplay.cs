using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDisplay : MonoBehaviour
{
    private bool leftRot;

    private bool rightRot;

    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rightRot)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * -rotateSpeed);
        }
        else if (leftRot)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }
    }

    public void startRight()
    {
        rightRot = true;
    }

    public void stopRight()
    {
        rightRot = false;
    }

    public void startLeft()
    {
        leftRot = true;
    }

    public void stopLeft()
    {
        leftRot = false;
    }
}
