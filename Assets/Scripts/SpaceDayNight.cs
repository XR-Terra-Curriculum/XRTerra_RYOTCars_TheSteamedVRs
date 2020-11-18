using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDayNight : MonoBehaviour
{
    [Tooltip("Grab the directional light for color changes")]
    public Light directionalLight;
    [Tooltip("Grab the directional light for color changes")]
    public Material skyboxNight;
    [Tooltip("Skybox for daytime")]
    public Material skyboxDay;
    [Tooltip("Ambient night sounds")]
    public AudioClip nightSound;
    [Tooltip("Ambient day sounds")]
    public AudioClip daySound;
    [Tooltip("Ambient Ocean sounds")]
    public AudioClip oceanSound;
    [Tooltip("Ocean skybox")]
    public Material skyboxOcean;


    private GameObject[] nightObjects;


    /// <summary>
    /// 0 is nightspace, 1 is day mars, 2 is ocean floor
    /// </summary>
    private int dayNight = 0;
    // Start is called before the first frame update
    void Start()
    {
        //tree material change is not worth it
        //treeSprites = GameObject.FindGameObjectsWithTag("Tree");

        //grab all objects exclusive to day in an array, start on daytime
        nightObjects = GameObject.FindGameObjectsWithTag("Night");
        setNight();
    }

    // Update is called once per frame
    void Update()
    {
        //debug code for change time on a keyboard
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Setting day");
            setDay();
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Setting night");
            setNight();
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("Setting ocean");
            setOcean();
        }
        
    }
    /// <summary>
    /// Apply all color and object changes to simulate nighttime
    /// </summary>
    public void setNight()
    {
        GetComponent<AudioSource>().clip = nightSound;
        GetComponent<AudioSource>().volume = 1;
        GetComponent<AudioSource>().Play();
        RenderSettings.skybox = skyboxNight;
        RenderSettings.fog = false;
        directionalLight.color = new Color(0, 17 / 255f, 58 / 255f);
        for (int i = 0; i < nightObjects.Length; i++)
        {
            nightObjects[i].SetActive(true);
        }
    }

    /// <summary>
    /// Apply all color and object changes to simulate daytime
    /// </summary>
    public void setDay()
    {
        GetComponent<AudioSource>().clip = daySound;
        GetComponent<AudioSource>().volume = .2f;
        GetComponent<AudioSource>().Play();
        RenderSettings.skybox = skyboxDay;
        RenderSettings.fog = true;
        RenderSettings.fogColor = new Color(231/255f, 19/255f, 0/255f);
        directionalLight.color = new Color(141/255f, 62 / 255f, 55 / 255f);
        for (int i = 0; i < nightObjects.Length; i++)
        {
            nightObjects[i].SetActive(false);
        }

    }

    public void setOcean()
    {
        GetComponent<AudioSource>().clip = oceanSound;
        GetComponent<AudioSource>().volume = .6f;
        GetComponent<AudioSource>().Play();
        RenderSettings.skybox = skyboxOcean;
        RenderSettings.fog = false;
        directionalLight.color = new Color(0 / 255f, 83 / 255f, 108 / 255f);
        for (int i = 0; i < nightObjects.Length; i++)
        {
            nightObjects[i].SetActive(false);
        }
    }

    //swap to the opposite time
    public void toggleTime()
    {
        if (dayNight == 2)
        {
            dayNight = 0;
        }
        else
        {
            dayNight++;
        }

        if (dayNight == 0)
        {
            setNight();
        }
        else if (dayNight == 1)
        {
            setDay();
        }
        else if (dayNight == 2)
        {
            setOcean();
        }
    }
}