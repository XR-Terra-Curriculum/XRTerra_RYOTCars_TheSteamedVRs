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

    public bool mute = false;
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
        
    }

    /// <summary>
    /// play the sequence. Does not play if muted, or has completed fully beforehand. Stops other sequences
    /// </summary>
    /// <param name="num"></param>
    public void playSequence(int num)
    {
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
    }

}
