using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollerGuardMovement : MonoBehaviour
{
    public GameObject thePlayer;
    public int moveSpeed;
    public int rotSpeed;

    private Rigidbody rb;

    public bool inChasingRange;
    public float chasingRange;

    public float distanceToPlayer;

    public LayerMask mask;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        moveSpeed = 10;
        rotSpeed = 20;
        chasingRange = 30;
    }

    void Update() => MoveTowardsPlayer();

    public void MoveTowardsPlayer()
    {
        distanceToPlayer = Vector3.Distance(thePlayer.transform.position, this.transform.position);
        if (distanceToPlayer <= chasingRange)
            inChasingRange = true;
        else
            inChasingRange = false;

        if (inChasingRange && !Physics.Linecast(transform.position, this.thePlayer.transform.position, mask))
        {
            Vector3 target = thePlayer.transform.position;
            target.y = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            transform.LookAt(target);
        }
        if (inChasingRange == false)
        {
            rb.velocity = Vector3.zero;
            rb.freezeRotation = true;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            rb.velocity = Vector3.zero;

        if (collision.gameObject.CompareTag("GuardProjectile"))
            rb.velocity = Vector3.zero;
    }
}