using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimController : MonoBehaviour
{

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void animateReach()
    {
        anim.SetBool("Reach" , true);
    }

    public void endReach()
    {
        anim.SetBool("Reach", false);
    }

    public void animateGrip()
    {
        anim.SetBool("Grip", true);
    }

    public void endGrip()
    {
        anim.SetBool("Grip", false);
    }
    public void animateGripTube()
    {
        anim.SetBool("GripTube", true);
    }

    public void endGripTube()
    {
        anim.SetBool("GripTube", false);
    }
    public void animateGripBall()
    {
        anim.SetBool("GripBall", true);
    }
    public void endGripBall()
    {
        anim.SetBool("GripBall", false);
    }

    public void animatePinch()
    {
        anim.SetBool("Pinch", true);
    }

    public void endPinch()
    {
        anim.SetBool("Pinch", false);
    }
    public void animatePoint()
    {
        anim.SetBool("Point", true);
    }

    public void endPoint()
    {
        anim.SetBool("Point", false);
    }
    public void animateThumbsUp()
    {
        anim.SetBool("ThumbsUp", true);
    }

    public void endThumbsUp()
    {
        anim.SetBool("ThumbsUp", false);
    }
}
