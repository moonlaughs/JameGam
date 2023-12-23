using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    
    [Range(0f, 2f)]
    [SerializeField] private float waypointSize = 1f;
    
    private void OnDrawGizmos()
    {
        foreach (Transform t in transform)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(t.position, waypointSize);
        }
    }
}
