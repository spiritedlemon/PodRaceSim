using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public int position;
    public GameObject pod;
    public AudioClip podSound;
    public bool played = false;

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
            case 1:
                if(!played) //if not already done, play sound
                {
                    AudioSource.PlayClipAtPoint(podSound, pod.transform.position);
                    played = true;
                }
                break;
            case 2:
                //Activate camera 2
                two.GetComponent<Camera>().enabled = true;
                //De-Activate Camera 1
                one.GetComponent<Camera>().enabled = false;
                break;
            case 5:
                //Activate camera 3
                three.GetComponent<Camera>().enabled = true;
                //De-Activate Camera 2
                two.GetComponent<Camera>().enabled = false;
                break;
            case 7:
                //Activate camera 4
                four.GetComponent<Camera>().enabled = true;
                //De-Activate Camera 3
                three.GetComponent<Camera>().enabled = false;
                break;
            case 9:
                //Activate camera 4
                five.GetComponent<Camera>().enabled = true;
                //De-Activate Camera 3
                four.GetComponent<Camera>().enabled = false;
                break;
            case 10:
                //Activate camera 4
                six.GetComponent<Camera>().enabled = true;
                //De-Activate Camera 3
                five.GetComponent<Camera>().enabled = false;
                break;
            case 11:
                //Activate camera 4
                seven.GetComponent<Camera>().enabled = true;
                //De-Activate Camera 3
                six.GetComponent<Camera>().enabled = false;
                break;
            case 0:
                //Activate camera 4
                one.GetComponent<Camera>().enabled = true;
                //De-Activate Camera 3
                seven.GetComponent<Camera>().enabled = false;
                played = false; //reset for audio
                break;

        }



    }
}
