using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModernDayNight : MonoBehaviour
{
    [Tooltip("Ambient day sound")]
    public AudioClip daySounds;
    [Tooltip("Ambient night sound")]
    public AudioClip nightSounds;
    [Tooltip("Grab all outdoor objects for changing")]
    public GameObject outDoorComponents;
    [Tooltip("Directional light for color changes")]
    public Light directionalLight;
    [Tooltip("Skybox to apply at night")]
    public Material skyboxNight;
    [Tooltip("Skybox to use during the day")]
    public Material skyboxDay;

    private Light[] children;
    private GameObject[] buildingSprites;
    private GameObject[] treeSprites;
    private GameObject[] cloudSprites;
    private GameObject[] nightObjects;

    private bool dayNight = true;
    // Start is called before the first frame update
    void Start()
    {
        //get arrays of all lights, buildings, clouds, trees and objects exclusively for nighttime
        children = outDoorComponents.GetComponentsInChildren<Light>();
        buildingSprites = GameObject.FindGameObjectsWithTag("Building");
        cloudSprites = GameObject.FindGameObjectsWithTag("Cloud");
        treeSprites = GameObject.FindGameObjectsWithTag("Tree");
        nightObjects = GameObject.FindGameObjectsWithTag("Night");
        setDay();
    }

    // Update is called once per frame
    void Update()
    {
        //debug code to change time with keyboard
        /*
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
        */
    }

    /// <summary>
    /// all changes necessary to enable night environment
    /// </summary>
    public void setNight()
    {
        GetComponent<AudioSource>().clip = nightSounds;
        GetComponent<AudioSource>().Play();
        Color nightTree = new Color(70 / 255f, 87 / 255f, 159 / 255f);
        Color nightBuilding = new Color(62 / 255f, 70 / 255f, 106 / 255f);
        Color nightCloud = new Color(51 / 255f, 71 / 255f, 96 / 242f);
        RenderSettings.skybox = skyboxNight;
        RenderSettings.fog = false;
        directionalLight.color = new Color(107f / 255f, 109f / 255f, 125/255f);
        for (int i = 0; i < children.Length; i++)
        {
            //turn on all the lights
            children[i].enabled = true;
        }
        for (int i = 0; i < buildingSprites.Length; i++)
        {
            buildingSprites[i].GetComponent<SpriteRenderer>().color = nightBuilding;
        }
        for (int i = 0; i < treeSprites.Length; i++)
        {
            treeSprites[i].GetComponent<SpriteRenderer>().color = nightTree;
        }
        for (int i = 0; i < cloudSprites.Length; i++)
        {
            cloudSprites[i].GetComponent<SpriteRenderer>().color = nightCloud;
        }
        for (int i = 0; i < cloudSprites.Length; i++)
        {
            cloudSprites[i].GetComponent<SpriteRenderer>().color = nightCloud;
        }
        for (int i = 0; i < nightObjects.Length; i++)
        {
            nightObjects[i].SetActive(true);
        }
    }

    /// <summary>
    /// all changes necessary to enable day environment
    /// </summary>
    public void setDay()
    {
        GetComponent<AudioSource>().clip = daySounds;
        GetComponent<AudioSource>().Play();
        Color dayTree = new Color(200/255f, 129/255f, 189/255f);
        Color dayBuilding = new Color(204/255f, 173/255f, 200/255f);
        Color dayCloud = new Color(245 / 255f, 214 / 255f, 200 / 242f);
        RenderSettings.skybox = skyboxDay;
        RenderSettings.fog = false;
        directionalLight.color = new Color(1, 244/255f, 214/255f);
        //turn off all the lights, change sprite coloration to day values
        for(int i = 0; i < children.Length; i++)
        {
            children[i].enabled = false;
        }
        for(int i = 0; i < buildingSprites.Length; i++)
        {
            buildingSprites[i].GetComponent<SpriteRenderer>().color = dayBuilding;
        }
        for(int i = 0; i < treeSprites.Length; i++)
        {
            treeSprites[i].GetComponent<SpriteRenderer>().color = dayTree;
        }
        for(int i = 0; i < cloudSprites.Length; i++)
        {
            cloudSprites[i].GetComponent<SpriteRenderer>().color = dayCloud;
        }
        for(int i = 0; i < cloudSprites.Length; i++)
        {
            cloudSprites[i].GetComponent<SpriteRenderer>().color = dayCloud;
        }
        for(int i = 0; i < nightObjects.Length; i++)
        {
            nightObjects[i].SetActive(false);
        }
    }

    //swap between times
    public void toggleTime()
    {
        SalesmanController.instance.playSequence(6);
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
