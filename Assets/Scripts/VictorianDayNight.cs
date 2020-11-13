using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictorianDayNight : MonoBehaviour
{
    public GameObject victorianMap;
    public Light directionalLight;
    public Material skyboxNight;
    public Material skyboxDay;

    public GameObject fog1;
    public GameObject fog2;
    public GameObject fog3;
    private Light[] children;

    private bool dayNight = false;

    public AudioClip daySound;
    public AudioClip nightSound;

    // Start is called before the first frame update
    void Start()
    {
        children = victorianMap.GetComponentsInChildren<Light>();
        setNight();
    }

    // Update is called once per frame
    void Update()
    {
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
    }

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
