using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeGuardShooting : MonoBehaviour
{
    public Transform thePlayer;
    public int projectileSpeed;

    public float detectionRange;
    public float distanceToPlayer;
    public bool isInRange;

    public GameObject guardProjectile;//shoots out from the guard;
    private Rigidbody theProjectile;

    public float timer;
    private int startSpawn;
    public float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        startSpawn = 1;
        theProjectile = guardProjectile.GetComponent<Rigidbody>();
        isInRange = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        //spawnDelay = 1;
        PlayerDetection();
        ShootAtPlayer();
        //timer += Time.deltaTime;
    }
    private void FixedUpdate()
    {
       
        MoveProjectile();
    }
    public void PlayerDetection()
    {
        distanceToPlayer = Vector3.Distance(thePlayer.transform.position, transform.position);
        if(distanceToPlayer <= detectionRange)
        {
            isInRange = true;
            
                ShootAtPlayer();
            
        }
        else
        {
            isInRange = false;
        }
    }
    public void ShootAtPlayer()
    {
        if (isInRange)
        {
            InvokeRepeating("SpawnProjectile", 10000 * Time.deltaTime, 9000000 * Time.deltaTime);
            
            //Instantiate(theProjectile, transform.position, this.transform.rotation);
            //timer = 0;
        }
    }
    public void SpawnProjectile()
    {
        Instantiate(theProjectile, transform.position, this.transform.rotation);
    }
    public void MoveProjectile()
    {
        float projectileSpeed = 30f;
        theProjectile.velocity = Vector3.forward * projectileSpeed;
    }
    
    
  
}
