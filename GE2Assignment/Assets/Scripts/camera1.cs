using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is used to rotate the camera to look at 'pod9'
 * This could be changed so the camera looks at the center point of the swarm but for the
 * sake of story it will follow subulba
 */


public class camera1 : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
 
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
    }
}
