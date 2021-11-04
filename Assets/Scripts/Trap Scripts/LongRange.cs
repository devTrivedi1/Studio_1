using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRange : MonoBehaviour
{
    public GameObject arrow;
    private int startSpawn;
    private int spawnDelay;

    private float firePower = 50f;
   

    private Vector3 offset;

    private float detectionRange = 20f;
    public float distanceToPlayer;
    public Transform thePlayer;
    public bool enemyInRange;
   
    // Start is called before the first frame update
    void Start()
    {
        startSpawn = 1;
        spawnDelay = 1;
        offset = new Vector3(0, -2, 0);
        InvokeRepeating("ReadyArrow", startSpawn, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        //DetectPlayer();
        //StopFiring();
        

    }
    private void FixedUpdate()
    {
        /*if (enemyInRange)
        {
            InvokeRepeating("ReadyArrow", startSpawn * Time.fixedDeltaTime, spawnDelay * Time.fixedDeltaTime);

        }*/
    }
    public void ReadyArrow()
    {
        Instantiate(arrow, transform.position + offset, this.transform.rotation);

    }
    public void StopFiring()
    {
        if (!enemyInRange)
        {
            CancelInvoke("ReadyArrow");
            //CancelInvoke("FireArrow");
        }
    }
    private void DetectPlayer()
    {
        distanceToPlayer = Vector3.Distance(thePlayer.transform.position, transform.position);
        if(distanceToPlayer <= detectionRange)
        {
            enemyInRange = true;
        }
        else
        {
            enemyInRange = false;
        }
    }

}
