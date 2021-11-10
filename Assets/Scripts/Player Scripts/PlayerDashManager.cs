using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashManager : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 targetDirectionX;
    public Vector3 targetDirectionZ;
    public float dashForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Dash();
    }
    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 dashDirectionH = -targetDirectionX - transform.position;
            dashDirectionH = dashDirectionH.normalized;
            dashDirectionH = dashDirectionH * dashForce;
            rb.AddForce(dashDirectionH);
        }
        
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 dashDirectionH = targetDirectionX - transform.position;
            dashDirectionH = dashDirectionH.normalized;
            dashDirectionH = dashDirectionH * dashForce;
            rb.AddForce(dashDirectionH);
        }

    }
}
