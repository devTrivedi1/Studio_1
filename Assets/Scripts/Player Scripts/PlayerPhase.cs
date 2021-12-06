using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhase : MonoBehaviour
{
	public bool canPhase;
	public PlayerDash playerDash;
	public BoxCollider playerCollider;

	// Start is called before the first frame update
	void Start()
	{
		canPhase = false;
		playerDash = GetComponent<PlayerDash>();
		playerCollider = GetComponent<BoxCollider>();

	}

	// Update is called once per frame
	void Update()
	{
		CheckPhaseConditions();
		ReEnableObstacleCollider();

	}
	public void CheckPhaseConditions()
	{
		if (playerDash.isDashing)
		{
			canPhase = true;
		}
		else if (playerDash.hasDashed)
		{
			canPhase = false;
		}
	}

	public void ReEnableObstacleCollider()
	{
		if (canPhase == false)
		{
			GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
			for (int i = 0; i < obstacles.Length; i++)
			{
				BoxCollider obstacleCollider = obstacles[i].GetComponent<BoxCollider>();

				obstacleCollider.enabled = true;
				Debug.Log("Enabled collider");

			}
		}
	}


	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Obstacle" && canPhase)
		{
			BoxCollider obstacleCollider = collision.gameObject.GetComponent<BoxCollider>();
			obstacleCollider.enabled = false;

			Debug.Log("Disabled Obstacle Collider");
		}

	}

}
