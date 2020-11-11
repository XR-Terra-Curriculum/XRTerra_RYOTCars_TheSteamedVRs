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

    public void animateGrip()
    {
        anim.SetBool("Grip", true);
    }

    public void animateGripTube()
    {
        anim.SetBool("GripTube", true);
    }

    public void animateGripBall()
    {
        anim.SetBool("GripBall", true);
    }

    public void animatePinch()
    {
        anim.SetBool("Pinch", true);
    }

    public void animatePoint()
    {
        anim.SetBool("Point", true);
    }

    public void animateThumbsUp()
    {
        anim.SetBool("ThumbsUp", true);
    }

    public void endReach()
    {
        anim.SetBool("Reach", false);
    }

    public void endGrip()
    {
        anim.SetBool("Grip", false);
    }

    public void endGripTube()
    {
        anim.SetBool("GripTube", false);
    }

    public void endGripBall()
    {
        anim.SetBool("GripBall", false);
    }

    public void endPinch()
    {
        anim.SetBool("Pinch", false);
    }

    public void endPoint()
    {
        anim.SetBool("Point", false);
    }

    public void endThumbsUp()
    {
        anim.SetBool("ThumbsUp", false);
    }
    public void endAnim()
    {
        Debug.Log("NoMore");
        anim.SetBool("Reach", false);
        anim.SetBool("Grip", false);
        anim.SetBool("GripTube", false);
        anim.SetBool("GripBall", false);
        anim.SetBool("Pinch", false);
        anim.SetBool("Point", false);
        anim.SetBool("ThumbsUp", false);
    }
}
