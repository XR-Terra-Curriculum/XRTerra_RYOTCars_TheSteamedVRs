using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    public int cutSceneNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //trigger the cutscene associate with this car to play. Do not trigger again upon returning home
        if (other.tag == "Showtime" && GetComponent<FollowPoint>().target == GetComponent<FollowPoint>().display)
        {
            SalesmanController.instance.playSequence(cutSceneNumber);
        }
        else if (other.tag == "Home")
        {
           SalesmanController.instance.stopSequence(cutSceneNumber);
        }
    }

}
