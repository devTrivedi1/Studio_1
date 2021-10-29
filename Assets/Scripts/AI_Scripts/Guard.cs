using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
	public Transform pathHolder;
    public float speed = 4f;
    public float waitTime = .3f;


	void Start()
	{
		Vector3[] wayPoints = new Vector3[pathHolder.childCount];
		for (int i = 0; i < wayPoints.Length; i++)
		{
			wayPoints[i] = pathHolder.GetChild(i).position;
		}

        StartCoroutine(FollowPath(wayPoints));
	}

    IEnumerator FollowPath(Vector3[] waypoints)
    {
        transform.position = waypoints[0];
        int targetWaypointIndex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointIndex];
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
            if (transform.position == targetWaypoint)
            {
                targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length; 
                //when targetWaypointIndex is equal to waypoints.Length, it goes back to zero
                targetWaypoint = waypoints [targetWaypointIndex];
                yield return new WaitForSeconds(waitTime);
            }
            yield return null;
        }
    }

	void OnDrawGizmos()
	{
		Vector3 startPosition = pathHolder.GetChild(0).position; //draws a waypoint line using the first Path child (waypoint)

		Vector3 previousPosition = startPosition;

		foreach (Transform waypoint in pathHolder)
		{
			Gizmos.DrawSphere(waypoint.position, .3f); //draws a sphere for eachwaypoint put out
			Gizmos.DrawLine(previousPosition, waypoint.position);
			previousPosition = waypoint.position;
		}
		Gizmos.DrawLine(previousPosition, startPosition); //closes the loop from the last position point to the start position waypoint again
	}
}
