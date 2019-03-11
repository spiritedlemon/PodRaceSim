﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 acceleration;
    public Vector3 force;
    public float mass = 1;
    public Vector3 target;
    public float maxSpeed = 5;
    public GameObject targetGameObject;
    public float slowingDistance = 10;

    public bool SeekEnabled = false;
    public bool ArriveEnabled = false;


    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, force * 5);
        Gizmos.DrawRay(transform.position, acceleration * 5);

    }

    public bool FollowPathEnabled = false;

    private Vector3 nextWaypoint;

    [Range(0.0f, 1.0f)]
    public float banking = 0.1f; 

    public Path path;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public Vector3 Seek(Vector3 target)
    {
        Vector3 desired = target - transform.position;
        desired.Normalize();
        desired *= maxSpeed;
        return desired - velocity;
    }


    public Vector3 Arrive(Vector3 target)
    {
        Vector3 toTarget = target - transform.position;
        float dist = toTarget.magnitude;

        float ramped = (dist / slowingDistance) * maxSpeed;
        float clamped = Mathf.Min(ramped, maxSpeed);
        Vector3 desired = clamped * (toTarget / dist);
        return desired - velocity;
    }

    Vector3 FollowPath()
    {
        nextWaypoint = path.NextWaypoint();
        
        if (!path.looped && path.IsLast())
        {
            return Arrive(nextWaypoint);
        }
        else
        {
            if (Vector3.Distance(transform.position, nextWaypoint) < 3)
            {
                path.AdvanceToNext();
            }
            return Seek(nextWaypoint);
        }
    }

    Vector3 CalculateForces()
    {
        Vector3 force = Vector3.zero;
        if (targetGameObject != null)
        {
            target = targetGameObject.transform.position;
        }
        
        force = Vector3.zero;
        if (SeekEnabled)
        {
            force += Seek(target);
        }
        if (ArriveEnabled)
        {
            force += Arrive(target);
        }

        if (FollowPathEnabled)
        {
            force += FollowPath();
        }


        return force;
    }

    // Update is called once per frame
    void Update()
    {
        force = CalculateForces();
        Vector3 acceleration = force / mass;
        
        velocity += acceleration * Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        if (velocity.magnitude > float.Epsilon)
        {
            Vector3 tempUp = Vector3.Lerp(transform.up, Vector3.up + (acceleration * banking), Time.deltaTime * 3.0f);
            transform.LookAt(transform.position + velocity, tempUp);
            transform.position += velocity * Time.deltaTime;
            velocity *= (1.0f - (damping * Time.deltaTime));
        }        
    }

    public float damping = 0.01f;
}
