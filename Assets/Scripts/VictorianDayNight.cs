using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictorianDayNight : MonoBehaviour
{
    [Tooltip("Grab the victorian map prefab")]
    public GameObject victorianMap;
    [Tooltip("directional light for color changes")]
    public Light directionalLight;
    [Tooltip("skybox used for nighttime")]
    public Material skyboxNight;
    [Tooltip("skybox used for daytime")]
    public Material skyboxDay;
    [Tooltip("First fog object")]
    public GameObject fog1;
    [Tooltip("Second fog object")]
    public GameObject fog2;
    [Tooltip("Third fog object")]
    public GameObject fog3;
    [Tooltip("Ambient day sounds")]
    public AudioClip daySound;
    [Tooltip("Ambient night sounds")]
    public AudioClip nightSound;


    private Light[] children;
    private bool dayNight = false;

    

    // Start is called before the first frame update
    void Start()
    {
        //get all lamp lights and start on night
        children = victorianMap.GetComponentsInChildren<Light>();
        setNight();
    }

    // Update is called once per frame
    void Update()
    {
        //debug code to change day and night with keyboard
        /*
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Setting day");
            setDay();
        }
        else if(Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Setting night");
            setNight();
        }
        */
    }

    /// <summary>
    /// all color changes needed for night environment
    /// </summary>
    public void setNight()
    {
        GetComponent<AudioSource>().clip = nightSound;
        GetComponent<AudioSource>().volume = .5f;
        GetComponent<AudioSource>().Play();
        fog1.SetActive(false);
        fog2.SetActive(false);
        fog3.SetActive(false);
        RenderSettings.skybox = skyboxNight;
        RenderSettings.fogDensity = .01f;
        RenderSettings.fogColor = new Color(30/255f, 37/255f, 49/255f);
        directionalLight.color = new Color(174f/255f, 191f/255f, 1);
        for (int i = 0; i < children.Length; i++)
        {
            //turn on all the lights
            children[i].enabled = true;
        }
        
    }

    /// <summary>
    /// all color changes needed for day environment
    /// </summary>
    public void setDay()
    {
        GetComponent<AudioSource>().clip = daySound;
        GetComponent<AudioSource>().volume = 1;
        GetComponent<AudioSource>().Play();
        fog1.SetActive(true);
        fog2.SetActive(true);
        fog3.SetActive(true);
        RenderSettings.skybox = skyboxDay;
        RenderSettings.fogDensity = .01f;
        RenderSettings.fogColor = new Color(1, 1, 1);
        directionalLight.color = new Color(1, 1, 1);
        for (int i = 0; i < children.Length; i++)
        {
            //turn off all the lights
            children[i].enabled = false;
        }

        directionalLight.enabled = true;
    }

    /// <summary>
    /// swap between times
    /// </summary>
    public void toggleTime()
    {
        if (dayNight)
        {
            setNight();
        }
        else
        {
            setDay();
        }
        dayNight = !dayNight;
    }
}
