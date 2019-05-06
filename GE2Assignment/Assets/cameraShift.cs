using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShift : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        while(this.GetComponent<Camera>().enabled == true)
        {

            Debug.Log("Hey there");
        }

        Debug.Log("now this");

    }
}
