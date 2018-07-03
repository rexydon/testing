using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMove : MonoBehaviour {
    public bool byWaypoints = false;
    public GameObject waypointList;
    private List<Vector3> waypoints = new List<Vector3>();
    private int count = 0;
    public KinimaticCore controlledAI;

    // Use this for initialization
    void Start () {
        if (byWaypoints)
        {
            foreach (Transform child in waypointList.transform)
            {
                waypoints.Add(child.position);
            }
            controlledAI.Seek(waypoints[count++]);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (byWaypoints)
        {
            if (!controlledAI.isSeekTargetSet)
            {
                controlledAI.Seek(waypoints[count++]);
                if (count == waypoints.Count)
                {
                    count = 0;
                }
            }
        }
    }
}
