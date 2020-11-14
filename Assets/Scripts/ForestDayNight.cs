using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestDayNight : MonoBehaviour
{
    [Tooltip("Link the forest environment to grab tree assets")]
    public GameObject forestEnvironment;
    [Tooltip("Grab the directional light for color changes")]
    public Light directionalLight;
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

    private GameObject[] treeSprites;
    private GameObject[] dayObjects;
    private bool dayNight = true;
    // Start is called before the first frame update
    void Start()
    {
        //tree material change is not worth it
        //treeSprites = GameObject.FindGameObjectsWithTag("Tree");

        //grab all objects exclusive to day in an array, start on daytime
        dayObjects = GameObject.FindGameObjectsWithTag("Day");
        setDay();
    }

    // Update is called once per frame
    void Update()
    {
        //debug code for change time on a keyboard
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
    /// Apply all color and object changes to simulate nighttime
    /// </summary>
    public void setNight()
    {
        GetComponent<AudioSource>().clip = nightSound;
        GetComponent<AudioSource>().Play();
        Color fogNight = new Color(29 / 255f, 32 / 255f, 46 / 255f);
        RenderSettings.skybox = skyboxNight;
        RenderSettings.fog = true;
        RenderSettings.fogColor = fogNight;
        directionalLight.color = new Color(89/255f, 95 / 255f, 123 / 255f);

        for (int i = 0; i < dayObjects.Length; i++)
        {
            dayObjects[i].SetActive(false);
        }

    }

    /// <summary>
    /// Apply all color and object changes to simulate daytime
    /// </summary>
    public void setDay()
    {
        GetComponent<AudioSource>().clip = daySound;
        GetComponent<AudioSource>().Play();
        Color fogDay = new Color(49/ 255f, 87 / 255f, 99 / 255f);
        RenderSettings.skybox = skyboxDay;
        RenderSettings.fog = true;
        RenderSettings.fogColor = fogDay;
        directionalLight.color = new Color(1, 244 / 255f, 214 / 255f);

        for (int i = 0; i < dayObjects.Length; i++)
        {
            dayObjects[i].SetActive(true);
        }

        //an attempt to change billboard tree material, too labor intensive and for not that much
        /*
        for (int i = 0; i < treeSprites.Length; i++)
        {
            Component[] treeFlats = treeSprites[i].GetComponentsInChildren<MeshRenderer>();

            foreach (MeshRenderer rend in treeFlats)
            {
                rend.material = dayTrees;
            }
                
        }
        */

    }

    //swap to the opposite time
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