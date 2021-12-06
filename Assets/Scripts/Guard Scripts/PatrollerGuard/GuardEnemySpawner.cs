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

    public int enemiesSpawned = 0;
    public int maxSpawn = 3;
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(Random.Range(-10, 10), 1.4f, Random.Range(-10, 10));
    }

    // Update is called once per frame
    void Update()
    {
        spawnDelay = 1;
        timer += Time.deltaTime;
    }
    public void SpawnEnemies()
    {
        if(enemiesSpawned < maxSpawn)
        {

        }
        if (timer > spawnDelay)
        {
            Instantiate(spawnEnemies, transform.TransformPoint(pos), transform.rotation);
            timer = 0;
        }
    }

}
