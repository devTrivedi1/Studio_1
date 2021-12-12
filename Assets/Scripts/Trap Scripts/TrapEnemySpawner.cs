using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapEnemySpawner : MonoBehaviour
{
	public GameObject[] enemies;
	public GameObject thePlayer;

	public float trapRange;
	public float playerDistanceToTrap;

	public bool inTriggerRange;

	public Vector3 spawnRange;
	// Start is called before the first frame update
	void Start()
	{
		thePlayer = GameObject.FindGameObjectWithTag("Player");
		
	}

	// Update is called once per frame
	void Update()
	{
		SpawnRandomEnemies();
		spawnRange = new Vector3(Random.Range(-5, 5), 1.8f, Random.Range(-5, 5));
	}
	public void SpawnRandomEnemies()
	{
		if (inTriggerRange)
		{
			for (int i = 0; i < enemies.Length; i++)
			{
				Instantiate(enemies[i], this.transform.TransformPoint(spawnRange), Quaternion.identity);
			}
		}

	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			inTriggerRange = true;
			SpawnRandomEnemies();
			Destroy(this.gameObject, 0.02f);
			
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			inTriggerRange = false;
		}
	}
}
