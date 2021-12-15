using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRange : MonoBehaviour
{
	private int startSpawn;
	public float spawnDelay;

	public GameObject arrow;
	private Vector3 offset;

	public float detectionRange = 20f;
	public float distanceToPlayer;
	public GameObject thePlayer;
	public bool enemyInRange;

	public float timer;
	void Start()
	{
		startSpawn = 1;
		offset = new Vector3(0, -2, 0);
		thePlayer = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		spawnDelay = 1;
		DetectPlayer();
		timer += Time.deltaTime;
	}

	private void DetectPlayer()
	{
		distanceToPlayer = Vector3.Distance(thePlayer.transform.position, transform.position);
		if (distanceToPlayer <= detectionRange)
		{
			enemyInRange = true;
			if (timer >= spawnDelay)
			{
				StartFiring();
			}
		}
		else
		{
			enemyInRange = false;
		}
	}
	public void StartFiring()
	{
		Instantiate(arrow, transform.position + offset, this.transform.rotation);
		timer = 0;
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Destroy(this);
		}
	}
}
