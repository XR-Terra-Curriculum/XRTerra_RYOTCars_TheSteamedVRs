using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSounds : MonoBehaviour
{
    public AudioClip engineStart;
    public AudioClip engineRun;
    public AudioClip carPickup;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playBeep()
    {
        GetComponent<AudioSource>().loop = false;
        GetComponent<AudioSource>().clip = carPickup;
        GetComponent<AudioSource>().Play();
    }

    public void playEngine()
    {
        GetComponent<AudioSource>().loop = true;
        GetComponent<AudioSource>().clip = engineRun;
        GetComponent<AudioSource>().Play();
    }
}
