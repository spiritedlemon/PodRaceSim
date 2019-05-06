using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShift : MonoBehaviour
{

    public GameObject thisCam; //Camera script is attatched to
    private Vector3 startpos; //Location camera will return to 


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

            Debug.Log("Hey there");
        }
        
        

    }
}
