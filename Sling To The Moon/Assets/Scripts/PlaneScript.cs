using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    public float slimeSpeed = 50f;
    private int waypointHeading = 0;
    private Transform headedTwoards;
    public float waypointSwapDistence = .2f;
    private Transform[] waypointList;

    // Start is called before the first frame update
    void Start()
    {
        waypointList = transform.parent.GetComponentInChildren<WayPointSetup>().points;
        headedTwoards = waypointList[waypointHeading];
    }

    // Update is called once per frame
    void Update()
    {
        MoveSlime();
    }

    private void MoveSlime()
    {
        if (Vector3.Distance(transform.position, headedTwoards.position) < waypointSwapDistence)
        {
            GetNextWaypoint();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, headedTwoards.position, slimeSpeed * Time.deltaTime);
            transform.LookAt(headedTwoards);
        }
    }

    private void GetNextWaypoint()
    {
        if (waypointHeading < waypointList.Length)
        {
            waypointHeading += 1;
        }
        else if (waypointHeading >= waypointList.Length)
        {
            waypointHeading = 0;
        }

        headedTwoards = waypointList[waypointHeading];
    }
}
