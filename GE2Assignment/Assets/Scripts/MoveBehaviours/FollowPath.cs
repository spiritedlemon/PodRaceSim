using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : SteeringBehaviour {

    public List<Vector3> waypointList = new List<Vector3>();

    public int next = 0;
    public bool looped = true;
    public float temp = 0.0f;

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

    /*
    public Vector3 alt3;
    public Vector3 alt4;
    public Vector3 alt5;
    public Vector3 alt6;
    public Vector3 alt7;
    */

    /*
    public void OnDrawGizmos()
    {
        if (isActiveAndEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, nextWaypoint);
        }
    }
    */

    public void Start()
    {
        //waypointList = Path.waypoints;

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
        //Debug.Log(next);
        return waypointList[next];
        
    }

    public void SwitchPath()
    {
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
                    //SwitchPath();
                    altCount = 3;
                    break;
                case 4:
                    //SwitchPath();
                    altCount = 4;
                    break;
                case 5:
                    SwitchPath();
                    altCount = 5;
                    break;
                case 6:
                    //SwitchPath();
                    altCount = 6;
                    break;
                default:
                    //for any value not on the alternate path route
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
                    print("How did I get here..." + altCount + "... " + altpath);
                    break;
            }
        }
        else
        {
            nextWaypoint = NextWaypoint();
        }

        if (Vector3.Distance(transform.position, nextWaypoint) < 6)
        {
            AdvanceToNext();
        }
        
        return boid.SeekForce(nextWaypoint);
        
    }
}
