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

	}
	public void CheckPhaseConditions()
	{
		if (playerDash.isDashing)
		{
			canPhase = true;
			ToggleObstacleCollider(false);

		}
		else if (playerDash.hasDashed)
		{
			canPhase = false;
			ToggleObstacleCollider(true);
		}
	}

	public void ToggleObstacleCollider(bool enabled)
	{
		GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
		for (int i = 0; i < obstacles.Length; i++)
		{
			BoxCollider obstacleCollider = obstacles[i].GetComponent<BoxCollider>();

			obstacleCollider.enabled = enabled;
			Debug.Log("Enabled collider");
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
