using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public int position;
    public GameObject pod;

    //Cameras
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject six;
    public GameObject seven;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        position = pod.GetComponent<FollowPath>().next;
        
        switch(position)
        {
            default:
                break;
            case 2:
                //
                break;
                

        }



    }
}
