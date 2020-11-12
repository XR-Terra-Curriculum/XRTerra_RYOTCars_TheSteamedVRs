using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalesmanController : MonoBehaviour
{
    public AudioSource voice;
    public Animator anim;
    public NarrationSequence[] speechList;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSequence(int num)
    {
        speechList[num].playSequence(anim, voice);
    }
}
