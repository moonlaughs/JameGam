using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    // stores a referenve to the waypoint system this object will use
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private float moveSpeed = 5f;
    [Range(0f, 15f)]
    [SerializeField] private float rotateSpeed = 4f;
    [SerializeField] private float distanceThreshhold = 0.1f;
    // current waypoint we are moving into
    private Transform currentWaypoint;

    // the rotation target for the current frame
    private Quaternion rotationGoal;
    // the directin to the next waypoint
    private Vector3 directionToWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        // set initial position to the first waypoint
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        // set the next waypoint target
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshhold)
        {
            
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        }
        RotateTowardsWaypoint();
    }

    // will slowly rotate agent
    private void RotateTowardsWaypoint()
    {
        directionToWaypoint = (currentWaypoint.position - transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(directionToWaypoint);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
    }
}
