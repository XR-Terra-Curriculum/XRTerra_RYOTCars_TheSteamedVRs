using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComputerText : MonoBehaviour
{
    public static ComputerText instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setFuture()
    {
        GetComponent<TextMeshProUGUI>().text = "An import from the distant future, " +
                                               "this unit boasts features unimaginable to a modern driver. " +
                                               "A perfect fit for the driver who loves pushing boundaries " +
                                               "and existing on the forefront of what humanity can accomplish. ";
    }

    public void blank()
    {
        GetComponent<TextMeshProUGUI>().text = "";
    }

    public void setSedan()
    {
        GetComponent<TextMeshProUGUI>().text = "Rated best in class for safety and comfort, " +
                                               "this vehicle is reliable and straightforward. " +
                                               "Great for getting yourself to work on time or " +
                                               "the whole family to their favorite vacation spot, " +
                                               "this modern classic won’t let you down. ";
    }

    public void setIntro()
    {
        GetComponent<TextMeshProUGUI>().text = "Welcome to Steam Engines and Beyond," +
                                               " the car dealership of the past, present and future." +
                                               " To begin shopping, simply select a vehicle and gently" +
                                               " toss it towards the display platform.";
    }

    public void setComponent()
    {
        GetComponent<TextMeshProUGUI>().text = "To switch vehicles, pickup a different car and toss it. " +
                                               "To customize a component of your selected vehicle," +
                                               " select it with your laser pointer and click your trigger.";
    }

    public void setOld()
    {
        GetComponent<TextMeshProUGUI>().text = "Above all else, you value class. What it lacks in speed and energy efficiency," +
                                               " this classic vehicle more than makes up for style and poise. " +
                                               "A perfect choice for a Sunday morning joy ride or rolling " +
                                               "up to the red carpet in the tried and true style of your ancestors.";
    }

    public void setSport()
    {
        GetComponent<TextMeshProUGUI>().text = "You live on the edge. Your hunger for speed is only" +
                                               " matched by your boldness and fearless spirit. " +
                                               "This vehicle is not for the faint of heart, " +
                                               "a perfect match for your inner thrill seeker.";
    }
}
