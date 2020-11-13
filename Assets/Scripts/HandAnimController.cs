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
        anim.SetBool("Reach", true);
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
}
