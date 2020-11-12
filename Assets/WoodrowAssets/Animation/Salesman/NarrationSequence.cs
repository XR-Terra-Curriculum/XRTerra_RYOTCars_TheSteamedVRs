using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrationSequence : MonoBehaviour
{
    private AudioSource localSpeaker;
    private Animator localAnim;
    public AudioClip voiceClip;

    public float startTime;

    public float endTime;

    public String animationName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (localSpeaker != null)
        {
            if (localSpeaker.time > endTime)
            {
                Debug.Log("Finished anim, back to Idle");
                localSpeaker.Stop();
                localAnim.SetBool(animationName, false);
            }
        }
    }

    public void playSequence(Animator publicAnim, AudioSource publicSpeaker)
    {
        localAnim = publicAnim;
        localSpeaker = publicSpeaker;
        localSpeaker.clip = voiceClip;
        localSpeaker.time = startTime;
        localSpeaker.Play();
        localAnim.SetBool(animationName, true);
    }
}
