using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
	public Transform pathHolder;
	public float speed = 6f;
	private float waitTime = .05f;
	private float turnSpeed = 180;

	public Light spotLight;
	public float viewDistance;
	public float viewAngle;

	public LayerMask viewMask;
	Color originalSpotLightColor;

	Transform player;

	void Start()
	{

        player = GameObject.FindGameObjectWithTag("Player").transform;
        originalSpotLightColor = spotLight.color;
		viewAngle = spotLight.spotAngle;

		Vector3[] wayPoints = new Vector3[pathHolder.childCount];
		for (int i = 0; i < wayPoints.Length; i++)
		{
			wayPoints[i] = pathHolder.GetChild(i).position;
		}

		StartCoroutine(FollowPath(wayPoints));
	}

    void Update()
    {
        if(CanSeePlayer())
        {
            spotLight.color = Color.red;
        }
        else
        {
            spotLight.color = originalSpotLightColor;
        }
    }

	IEnumerator FollowPath(Vector3[] waypoints)
	{
		transform.position = waypoints[0];
		int targetWaypointIndex = 1;
		Vector3 targetWaypoint = waypoints[targetWaypointIndex];
		transform.LookAt(targetWaypoint);
		while (true)
		{
			transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
			if (transform.position == targetWaypoint)
			{
				targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
				//when targetWaypointIndex is equal to waypoints.Length, it goes back to zero
				targetWaypoint = waypoints[targetWaypointIndex];
				yield return new WaitForSeconds(waitTime);
				yield return StartCoroutine(TurnToFace(targetWaypoint));
			}
			yield return null;
			
		}
	}

	IEnumerator TurnToFace(Vector3 lookTarget)
	{
		Vector3 directionToLookTarget = (lookTarget - transform.position).normalized;
		float targetAngle = 90 - Mathf.Atan2(directionToLookTarget.z, directionToLookTarget.x) * Mathf.Rad2Deg;

		while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f)
		{
			float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
			transform.eulerAngles = Vector3.up * angle;

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

		Gizmos.color = Color.cyan;
		Gizmos.DrawRay(transform.position, transform.forward * viewDistance);
	}

    bool CanSeePlayer()
    {
        if(Vector3.Distance(transform.position, player.position) < viewDistance)
        {
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            float angleBetweenGuardAndPlayer = Vector3.Angle (transform.forward, dirToPlayer);
            if(angleBetweenGuardAndPlayer < viewAngle /2f)
            {
                if(!Physics.Linecast(transform.position, player.position, viewMask))
                {
                    return true; 
                }
            }
        }
        return false;  
    }
}
