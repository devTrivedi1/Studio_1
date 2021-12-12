using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardEnemySpawner : MonoBehaviour
{
	[SerializeField] private GameObject spawnEnemies;
	private int startSpawn = 1;
	private int spawnDelay = 1;
	private Vector3 pos;
	private float timer;

	public int currentSpawnCount;
	public int maxSpawnCount;


	void Start()
	{
		pos = new Vector3(Random.Range(-10, 10), 1.4f, Random.Range(-10, 10));
		currentSpawnCount = 0;
	}

	// Update is called once per frame
	void Update()
	{
		spawnDelay = 1;
		timer += Time.deltaTime;
		LimitSpawning();
	}
	public void SpawnEnemies()
	{
		if (timer > spawnDelay)
		{
			Instantiate(spawnEnemies, transform.TransformPoint(pos), transform.rotation);
			currentSpawnCount++;
			timer = 0;
		}
	}

	public void LimitSpawning()
	{
		if (currentSpawnCount >= maxSpawnCount)
		{
			this.enabled = false;
		}
	}
}
