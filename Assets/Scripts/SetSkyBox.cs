using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSkyBox : MonoBehaviour
{
    public Material skybox;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = skybox;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
