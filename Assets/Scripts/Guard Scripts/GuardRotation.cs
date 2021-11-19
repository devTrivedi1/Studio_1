using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardRotation : MonoBehaviour
{
    private GameObject thePlayer;
    public int rotSpeed;

    private Rigidbody rb;

    public bool inFacingRange;
    public float facingRange;

    public float distanceToPlayer;
    public LayerMask mask;

    
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        rotSpeed = 20;
        facingRange = 40;

      
    }

    // Update is called once per frame
    void Update()
    {
        FaceThePlayer();
    }
    public void FaceThePlayer()
    {
        distanceToPlayer = Vector3.Distance(thePlayer.transform.position, this.transform.position);
        if (distanceToPlayer <= facingRange)
        {
            inFacingRange = true;
        }
        else
        {
            inFacingRange = false;
        }
        if (!Physics.Linecast(transform.position, this.thePlayer.transform.position, mask) && inFacingRange)
        {
            Vector3 direction = thePlayer.transform.position - this.transform.position;
            transform.forward = direction;
        }
       
    }
   
}
