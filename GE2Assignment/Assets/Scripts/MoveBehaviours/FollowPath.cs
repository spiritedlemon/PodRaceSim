using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : SteeringBehaviour {

    public List<Vector3> waypointList = new List<Vector3>();

    public int next = 0;
    public bool looped = true;
    public float temp = 0.0f;

    //used for tracking which path the pod is on and where abouts they are on it
    public Boolean altpath = false;
    public int altCount = 0;

    public Path path;
    Vector3 nextWaypoint;
    public GameObject pathGO;

    //These store alternate path points for the pods
    public GameObject alt3;
    public GameObject alt4;
    public GameObject alt5;
    public GameObject alt6;
    public GameObject alt7;

    public void Start()
    {
        //Get standard past and store in list
        pathGO = GameObject.Find("CoursePath");

        waypointList.Clear();
        int count = pathGO.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            waypointList.Add(pathGO.transform.GetChild(i).position);
        }
    }

    public Vector3 NextWaypoint()
    {
        return waypointList[next];
        
    }

    public void SwitchPath()
    {
        //get random variable and use it to split pods into different paths
        temp = UnityEngine.Random.Range(0.0f, 1.0f);

        if(temp >= 0.5f)
        {
            altpath = !altpath; //toggle boolean
        }
        
    }

    public void AdvanceToNext()
    {
        if (looped)
        {
            
            next = (next + 1) % waypointList.Count;

            switch (next)
            {
                case 2:
                    SwitchPath();
                    altCount = 2;
                    break;
                case 3:
                    //No Switch Available Here
                    altCount = 3;
                    break;
                case 4:
                    if(altpath == false)
                    {
                       SwitchPath();
                    }
                    
                    altCount = 4;
                    break;
                case 5:
                    if(altpath == true)
                    {
                        SwitchPath();
                    }
                    
                    altCount = 5;
                    break;
                case 6:
                    //No Switch Available Here
                    altCount = 6;
                    break;
                case 7:
                    if(altpath == true)
                    {
                        altpath = !altpath;
                    }
                    break;
                default:
                    //for the rest of the course outside of the rock field
                    break;

            }

            
        }
        else
        {
            if (next != waypointList.Count - 1)
            {
                next++;
            }
        }
    }

    public bool IsLast()
    {
        return next == waypointList.Count - 1;
    }

    public override Vector3 Calculate()
    {

        if (altpath == true)
        {
            //Tracks where the pod is on the inner path
            switch (altCount)
            {
                case 2:
                    nextWaypoint = alt3.transform.position;
                    break;
                case 3:
                    nextWaypoint = alt4.transform.position;
                    break;
                case 4:
                    nextWaypoint = alt5.transform.position;
                    break;
                case 5:
                    nextWaypoint = alt6.transform.position;
                    break;
                case 6:
                    nextWaypoint = alt7.transform.position;
                    break;
                default:
                    print("How did I get here..." + altCount + "... " + altpath); //Hasn't been triggered in testing
                    break;
            }
        }
        else
        {
            nextWaypoint = NextWaypoint(); //If on standard path
        }

        if (Vector3.Distance(transform.position, nextWaypoint) < 6)
        {
            AdvanceToNext();
        }
        
        return boid.SeekForce(nextWaypoint);
        
    }
}
