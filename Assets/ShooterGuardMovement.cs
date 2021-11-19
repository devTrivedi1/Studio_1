using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterGuardMovement : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.velocity = Vector3.zero;

        }
    }

}
