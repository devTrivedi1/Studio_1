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

    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        rotSpeed = 20;
        facingRange = 60;
    }

    void Update() => FaceThePlayer();

    public void FaceThePlayer()
    {
        distanceToPlayer = Vector3.Distance(thePlayer.transform.position, this.transform.position);
        if (distanceToPlayer <= facingRange)
            inFacingRange = true;
        else
            inFacingRange = false;

        if (inFacingRange && !Physics.Linecast(transform.position, thePlayer.transform.position, mask))
        {
            //Vector3 direction = thePlayer.transform.position - this.transform.position;
            //transform.forward = direction;

            Vector3 target = thePlayer.transform.position;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }
}