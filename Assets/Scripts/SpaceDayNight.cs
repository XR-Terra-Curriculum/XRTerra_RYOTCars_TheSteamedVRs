using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDayNight : MonoBehaviour
{
    [Tooltip("Link the forest environment to grab tree assets")]
    public GameObject forestEnvironment;
    [Tooltip("Grab the directional light for color changes")]
    public Light directionalLight;
    [Tooltip("Grab the directional light for color changes")]
    public Light directionalLightDown;
    [Tooltip("Skybox for nighttime")]
    public Material skyboxNight;
    [Tooltip("Skybox for daytime")]
    public Material skyboxDay;
    [Tooltip("Ambient night sounds")]
    public AudioClip nightSound;
    [Tooltip("Ambient day sounds")]
    public AudioClip daySound;
    [Tooltip("This is currently unused")]
    public Material dayTrees;
    [Tooltip("This is currently unused")]
    public Material nightTrees;
    
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
        nightObjects = GameObject.FindGameObjectsWithTag("Day");
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
        GetComponent<AudioSource>().Play();
        RenderSettings.skybox = skyboxNight;
        RenderSettings.fog = false;
        directionalLight.color = new Color(0, 17 / 255f, 58 / 255f);
        directionalLightDown.color = new Color(0, 17 / 255f, 58 / 255f);
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
       

    }

    public void setOcean()
    {
       
    }

    //swap to the opposite time
    public void toggleTime()
    {
        dayNight++;
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