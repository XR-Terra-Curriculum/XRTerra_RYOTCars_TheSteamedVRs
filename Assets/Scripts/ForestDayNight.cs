using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestDayNight : MonoBehaviour
{
    public GameObject forestEnvironment;
    public Light directionalLight;
    public Material skyboxNight;
    public Material skyboxDay;
    private GameObject[] treeSprites;
    private GameObject[] dayObjects;
    public AudioClip nightSound;
    public AudioClip daySound;
    public Material dayTrees;
    public Material nightTrees;

    private bool dayNight = true;
    // Start is called before the first frame update
    void Start()
    {
        treeSprites = GameObject.FindGameObjectsWithTag("Tree");
        dayObjects = GameObject.FindGameObjectsWithTag("Day");
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