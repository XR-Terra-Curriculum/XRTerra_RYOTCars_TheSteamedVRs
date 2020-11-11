using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarList : MonoBehaviour
{
    [Tooltip("Cars in this array should be a CarPrefab with the car model added on as a child at 0,0,0.")]
    public GameObject[] carArray;

    [Tooltip("Each home corresponds directly to the car at the " +
             "same index in carArray. Each home should be made of the carhome prefab")]
    public Transform[] homeArray;

    [Tooltip("The location of the car display")]
    public Transform displayLocation;
    // Start is called before the first frame update
    void Start()
    {

        //for each car in the list, assign a home and connect them to the display location
        for(int i = 0; i < carArray.Length; i++)
        {
            carArray[i].GetComponent<FollowPoint>().target = displayLocation;
            carArray[i].GetComponent<FollowPoint>().display = displayLocation;
            if (homeArray[i] != null)
            {
                carArray[i].GetComponent<FollowPoint>().home = homeArray[i];
            }
            else
            {
                carArray[i].GetComponent<FollowPoint>().home = homeArray[0];
            }

            //for each car, match the position rotation and scale of the home to begin
            carArray[i].transform.position = carArray[i].GetComponent<FollowPoint>().home.transform.position;
            carArray[i].transform.localScale = carArray[i].GetComponent<FollowPoint>().home.transform.localScale;
            carArray[i].transform.rotation = carArray[i].GetComponent<FollowPoint>().home.transform.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
