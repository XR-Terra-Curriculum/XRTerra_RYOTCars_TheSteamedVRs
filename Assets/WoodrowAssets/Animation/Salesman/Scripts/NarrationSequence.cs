using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrationSequence : MonoBehaviour
{
    [Tooltip("Audio to be used")]
    public AudioClip voiceClip;
    [Tooltip("Second in audio to begin")]
    public float startTime;
    [Tooltip("Second in audio to end")]
    public float endTime;
    [Tooltip("String associated with animation in animator")]
    public String animationName;
    [Tooltip("transform to rotates towards during cutscene")]
    public Transform lookPosition;
    [Tooltip("Do not alter. Tracks completion of cutscene")]
    public bool complete = false;
    [Tooltip("Option to have another cutscene triggered by the conclusion of this one")]
    public bool triggerNext;
    [Tooltip("which scene would you like to trigger")]
    public NarrationSequence next;
    [Tooltip("Time between ending and triggering next")]
    public float followTime;

    private bool acting = false;
    private AudioSource localSpeaker;
    private Animator localAnim;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the cutscene has begin and is currently in session, check to see if it is over
        //rotate the salesman correctly towards lookposition
        if (localSpeaker != null && acting)
        {
            Vector3 goalrotation = lookPosition.position - SalesmanController.instance.gameObject.transform.position;
            goalrotation.y = 0.0f;
            SalesmanController.instance.gameObject.transform.rotation = Quaternion.RotateTowards(SalesmanController.instance.gameObject.transform.rotation, Quaternion.LookRotation(goalrotation), Time.time * 5);
            if (localSpeaker.time > endTime)
            {
                complete = true;
                stopSequence();
                //begin next scene if triggernext is enabled
                if (triggerNext)
                {
                    StartCoroutine(DelayNextSequence());
                }
            }
        }
    }

    //plays the sequence associated with this file
    public void playSequence(Animator publicAnim, AudioSource publicSpeaker)
    {
        if (!complete && !acting)
        {
            acting = true;
            localAnim = publicAnim;
            localSpeaker = publicSpeaker;
            localSpeaker.clip = voiceClip;
            localSpeaker.time = startTime;
            localSpeaker.Play();
            localAnim.SetBool(animationName, true);
        }
    }

    //delays the triggernext scene
    IEnumerator DelayNextSequence()
    {
        yield return new WaitForSeconds(followTime);
        next.playSequence(localAnim, localSpeaker);
    }

    //stops the scene
    public void stopSequence()
    {
        if (localAnim != null && acting)
        {
            Debug.Log("Finished anim, back to Idle");
            localSpeaker.Stop();
            localAnim.SetBool(animationName, false);
            acting = false;
        }
    }

    //forces a scene to play even if it has already been played
    public void forcePlaySequence(Animator publicAnim, AudioSource publicSpeaker)
    {
        complete = false;
        playSequence(publicAnim, publicSpeaker);
    }

    public bool getActing()
    {
        return acting;
    }
}
