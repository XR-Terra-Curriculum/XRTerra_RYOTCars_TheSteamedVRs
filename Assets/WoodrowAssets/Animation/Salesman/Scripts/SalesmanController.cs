using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalesmanController : MonoBehaviour
{
    [Tooltip("Object to rotate towards and compensate for animation discrepancies")]
    public Transform lookOrientation;
    [Tooltip("AudioPlayer for voice")]
    public AudioSource voice;
    [Tooltip("link the animator")]
    public Animator anim;
    [Tooltip("The list of NarrationSequence objects containing cutscenes")]
    public NarrationSequence[] speechList;
    public static SalesmanController instance = null;

    private bool queueNext;
    private int recentSequence;
    private int nextSequence;
    public bool mute = false;
    private int lastTry;
    void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    // Start is called before the first frame update
    void Start()
    {   
        //wait 5 seconds then start intro
        StartCoroutine(WaitAndPlay(0, 5f));
    }

    // Update is called once per frame
    void Update()
    {
        
        if (speechList[recentSequence].getActing() == false && queueNext)
        {
            forcePlayerSequence(nextSequence);
            queueNext = false;
        }
    }

    /// <summary>
    /// play the sequence. Does not play if muted, or has completed fully beforehand. Stops other sequences
    /// </summary>
    /// <param name="num"></param>
    public void playSequence(int num)
    {
        lastTry = num;
        /*
        if (num == 0)
        {
            ComputerText.instance.setIntro();
        }
        else if (num == 1)
        {
            ComputerText.instance.setSedan();
        }
        else if (num == 2)
        {
            ComputerText.instance.setSport();
        }
        else if (num == 4)
        {
            ComputerText.instance.setOld();
        }
        else if (num == 5)
        {
            ComputerText.instance.setFuture();
        }
        */

        if (!speechList[num].complete && !mute)
        {
            for (int i = 0; i < speechList.Length; i++)
            {
                if (i != num)
                {
                    speechList[i].stopSequence();
                }
            }
            StopAllCoroutines();
            speechList[num].playSequence(anim, voice);
            recentSequence = num;
        }
    }

    /// <summary>
    /// stops all sequences immediately
    /// </summary>
    public void stopAllSequence()
    {
        foreach (NarrationSequence cutscene in speechList)
        {
            cutscene.stopSequence();
        }
    }

    /// <summary>
    /// stops an individual sequence cutscene
    /// </summary>
    /// <param name="num"></param>
    public void stopSequence(int num)
    {
        speechList[num].stopSequence();
    }

    /// <summary>
    /// plays a cutscene sequence even if muted or already done
    /// </summary>
    /// <param name="num"></param>
    public void forcePlayerSequence(int num)
    {
        foreach (NarrationSequence cutscene in speechList)
        {
            cutscene.stopSequence();
        }
        StopAllCoroutines();
        speechList[num].forcePlaySequence(anim, voice);
    }


    IEnumerator WaitAndPlay(int num, float time)
    {
        // suspend execution for time seconds
        yield return new WaitForSeconds(time);
        playSequence(num);
    }

    /// <summary>
    /// toggles mute
    /// </summary>
    public void toggleMute()
    {
        mute = !mute;
        if (mute)
        {
            stopAllSequence();
        }
        else
        {
            playSequence(lastTry);
        }
    }


    public void queueSequence(int num)
    {
        nextSequence = num;
        queueNext = true;
    }

    public void queueLast()
    {
        queueNext = true;
        nextSequence = recentSequence;
        playSequence(7);
        Debug.Log(nextSequence);
    }
}
