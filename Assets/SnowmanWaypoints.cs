using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanWaypoints : MonoBehaviour
{
    [Range(0f, 2f)]
    [SerializeField] private float waypointSize = 1f;
    [Header("Path settings")]
    // agent should go from 1st to last or vice versa
    [SerializeField] private bool canLoop = true;
    // move forward or backwards
    [SerializeField] private bool isMovingForward = true;

    private void OnDrawGizmos()
    {
        foreach (Transform t in transform)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(t.position, waypointSize);
        }

        Gizmos.color = Color.red;
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }

        if (canLoop)
            Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position, transform.GetChild(0).position);
    }

    // get the correct next waypoint based on a direction
    public Transform GetNextWaypoint(Transform currentWaypoint)
    {
        if (currentWaypoint == null)
        {
            return transform.GetChild(0);
        }

        // stores index of current waypoint
        int currentIndex = currentWaypoint.GetSiblingIndex();
        // stores theindex of the next waypoint to travel towards
        int nextIndex = currentIndex;

        if (isMovingForward)
        {
            nextIndex += 1;

            if (nextIndex == transform.childCount)
            {
                if (canLoop)
                    nextIndex = 0;
                else
                {
                    nextIndex -= 1;
                }
            }
        }
        else
        {
            nextIndex -= 1;
            if (nextIndex < 0)
            {
                if (canLoop)
                    nextIndex = transform.childCount - 1;
                else
                {
                    nextIndex += 1;
                }
            }
        }
        return transform.GetChild(nextIndex);
    }
}
