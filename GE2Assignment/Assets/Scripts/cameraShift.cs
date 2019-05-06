using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShift : MonoBehaviour
{

    public GameObject thisCam; //Camera script is attatched to
    private Vector3 startpos; //Location camera will return to 

    public bool moveRight = false; //
    public int camSpeed = 1;


    // Start is called before the first frame update
    void Start()
    {
        startpos = thisCam.transform.position; //save start point
    }

    // Update is called once per frame
    void Update()
    {
        
        if(thisCam.GetComponent<Camera>().enabled == true)
        {
            if(!moveRight)
            {
                thisCam.transform.Translate(Vector3.right * Time.deltaTime * camSpeed, Space.World);
            }
            
        }

        //When diabled set back to start
        if (thisCam.GetComponent<Camera>().enabled == false)
        {
            thisCam.transform.position = startpos;

        }



    }
}
