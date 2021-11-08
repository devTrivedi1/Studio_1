using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTraps : MonoBehaviour
{
    public GameObject theSpikes;
    
    public float springSpeed;
    private Vector3 pos;//For moving the trap spikes.
    private Rigidbody rb;//To reference the spike's rigidbody.

    public Vector3 maxRisePos;
    public bool reachedMaxPos;

    public Vector3 maxFallPos;
    public float trapMoveSpeed;
    public int startTime;
    public int delay;

    public bool playerOnTrap;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        pos = Vector3.up;
        rb = theSpikes.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOnTrap)
        {
            /*InvokeRepeating("SpikeMoveUp", startTime, delay);
            StopRising();*/
            Vector3 trapPos = Vector3.Lerp(theSpikes.transform.position, maxRisePos, trapMoveSpeed * Time.deltaTime);
            theSpikes.transform.position = trapPos;
        }
        //if (reachedMaxPos)
        //{
            /*CancelInvoke("SpikeMoveUp");
            StartFalling();*/
            //Vector3 trapPos = Vector3.Lerp(maxRisePos, maxFallPos, trapMoveSpeed * Time.deltaTime);
        //}
       

    }
    private void FixedUpdate()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")//Player touches the trap plate, spikes spring up.
        {
            playerOnTrap = true;
            /*if (playerOnTrap)
            {
                InvokeRepeating("SpikeMoveUp", startTime, delay);
               
            }*/
        }
        if (collision.gameObject.tag == "Player" && rb.position == maxFallPos && playerOnTrap)
        {
            InvokeRepeating("SpikeMoveUp", startTime, delay);
            
        }
    
    }

    private void SpikeMoveUp()
    {
        rb.AddForce(pos * springSpeed, ForceMode.Impulse);
    }

    public void StopRising()
    {
        if(rb.position.y >= maxRisePos.y)
        {
            reachedMaxPos = true;
            //Vector3 reset = new Vector3(0, -springSpeed, 0);
            rb.velocity = Vector3.zero;
            Debug.Log("reachedMaxPos " + reachedMaxPos);
            Debug.Log("velocity is " + rb.velocity);
        }
    }
    public void StartFalling()
    {
        if (reachedMaxPos)
        {
            rb.velocity = -pos * springSpeed;
           
        }
        if(rb.position.y <= maxFallPos.y)
        {
            reachedMaxPos = false;
            rb.velocity = Vector3.zero;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerOnTrap = false;
        }
    }
}
