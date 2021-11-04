using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRange : MonoBehaviour
{
    public GameObject arrow;
    private int startSpawn;
    public float spawnDelay;

    public float firePower;
   

    private Vector3 offset;

    public float detectionRange;
    public float distanceToPlayer;
    public Transform thePlayer;
    public bool enemyInRange;

    public float timer;
   
    // Start is called before the first frame update
    void Start()
    {
        startSpawn = 1;
       
        offset = new Vector3(0, -2, 0);
       
    }

    // Update is called once per frame
    void Update()
    {
        spawnDelay = 2;
        DetectPlayer();
        
        timer += Time.deltaTime;

    }
    
    
   
    private void DetectPlayer()
    {
        distanceToPlayer = Vector3.Distance(thePlayer.transform.position, transform.position);
        if(distanceToPlayer <= detectionRange)
        {
            enemyInRange = true;
            Debug.Log("Player is in range");
            if(timer >= spawnDelay)
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

}
