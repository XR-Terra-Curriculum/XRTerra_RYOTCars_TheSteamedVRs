using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModernDayNight : MonoBehaviour
{
    public AudioClip daySounds;
    public AudioClip nightSounds;
    public GameObject outDoorComponents;
    public Light directionalLight;
    public Material skyboxNight;
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
    }

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
