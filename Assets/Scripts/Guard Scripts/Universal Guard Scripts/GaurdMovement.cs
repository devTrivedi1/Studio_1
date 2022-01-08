using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaurdMovement : MonoBehaviour
{

    public GameObject thePlayer;
    public float moveSpeed;
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
        rotSpeed = 30;
        chasingRange = 60;
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

            Vector3 moveDirection = (thePlayer.transform.position - this.transform.position).normalized;
            rb.AddForce(moveDirection * moveSpeed);
            transform.LookAt(target);

            moveSpeed += 5.5f * Time.deltaTime;
            if (moveSpeed >= 40)
                moveSpeed = 40f;
        }
        if (inChasingRange == false)
        {
            rb.velocity = Vector3.zero;
            rb.freezeRotation = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
    }
}