﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : SteeringBehaviour {

    public List<Vector3> waypointList = new List<Vector3>();

    public int next = 0;
    public bool looped = true;
    public float test = 0.0f;

    public Path path;

    Vector3 nextWaypoint;

    public GameObject pathGO;

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
        test = UnityEngine.Random.Range(0.0f, 1.0f);

        if(test >= 0.5f)
        {
            Debug.Log("hey" + test);
        }
        Debug.Log(test);
    }

    public void AdvanceToNext()
    {
        if (looped)
        {
            next = (next + 1) % waypointList.Count;
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
        nextWaypoint = NextWaypoint();
        //Debug.Log(nextWaypoint);
        if (Vector3.Distance(transform.position, nextWaypoint) < 6)
        {
            AdvanceToNext();
        }

        SwitchPath();

        return boid.SeekForce(nextWaypoint);
    }
}
