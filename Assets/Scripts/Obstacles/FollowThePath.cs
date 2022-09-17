using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    private GameObject Player;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;

    // Use this for initialization
    private void Start()
    {

        transform.position = waypoints[waypointIndex].transform.position;
    }

    private void Update()
    {
        Move();

    }

    // Method that actually make Enemy walk
    private void Move()
    {
        if (waypointIndex <= waypoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position,
               waypoints[waypointIndex].transform.position,
               moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                if (waypointIndex == waypoints.Length - 1)
                {
                    waypointIndex = 0;
                }
                else
                {
                    waypointIndex += 1;
                }
            }
        }
    }
}
