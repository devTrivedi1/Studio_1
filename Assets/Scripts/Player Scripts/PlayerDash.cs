using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public Rigidbody rb;
    public float dashForce;
    public float startDashTimer;
    public float dashSpeed;
    private float curretDashTimer;
    private float dashDirection;

    public bool isDashing;
    private Vector3 DashTo;
    private Vector3 offset = new Vector3(0, 1.5f, 0);

    private float dashCoolDown;
    public float dashCoolDownReset;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dashCoolDown = dashCoolDownReset;
    }

    // Update is called once per frame
    void Update()
    {
        dashDirection = Input.GetAxis("Horizontal");
        //Dash();
        DashCoolDown();
    }
    private void FixedUpdate()
    {
        Dash();
    }
    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 left = new Vector3(-dashForce, 0, 0);
            isDashing = true;
            curretDashTimer = startDashTimer;
            rb.velocity = Vector3.zero;
            
            if (isDashing)
            {
                DashTo = Vector3.MoveTowards(transform.position, transform.InverseTransformDirection(left + offset), dashSpeed * Time.deltaTime);
                transform.position = DashTo;
                curretDashTimer -= Time.deltaTime;
                Debug.Log("current dash t is " + curretDashTimer);
               
            }
            if (curretDashTimer == 0)
            {
                isDashing = false;
            }

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 right = new Vector3(dashForce, 0, 0);
            isDashing = true;
            curretDashTimer = startDashTimer;
            rb.velocity = Vector3.zero;

            if (isDashing)
            {
                DashTo = Vector3.MoveTowards(transform.position, transform.InverseTransformDirection(right + offset), dashSpeed * Time.deltaTime);
                transform.position = DashTo;
                curretDashTimer -= Time.deltaTime;
                if (curretDashTimer == 0)
                {
                    isDashing = false;
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector3 forwards = new Vector3(0, 0, dashForce);
            isDashing = true;
            curretDashTimer = startDashTimer;
            rb.velocity = Vector3.zero;

            if (isDashing)
            {
                DashTo = Vector3.MoveTowards(transform.position, transform.InverseTransformDirection(forwards + offset), dashSpeed * Time.deltaTime);
                transform.position = DashTo;
                curretDashTimer -= Time.deltaTime;
                if (curretDashTimer == 0)
                {
                    isDashing = false;
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 backwards = new Vector3(0, 0, -dashForce);
            isDashing = true;
            curretDashTimer = startDashTimer;
            rb.velocity = Vector3.zero;

            if (isDashing)
            {
                DashTo = Vector3.MoveTowards(transform.position, transform.InverseTransformDirection(backwards + offset), dashSpeed * Time.deltaTime);
                transform.position = DashTo;
                curretDashTimer -= Time.deltaTime;
                if (curretDashTimer == 0)
                {
                    isDashing = false;
                }
            }

        }
    }
    public void DashCoolDown()
    {
        if (isDashing == false)
        {
            dashCoolDown -= Time.deltaTime;
            if(dashCoolDown > 0)
            {
                isDashing = false;
                Debug.Log("cooldown time is " + dashCoolDown);
            }
            if(dashCoolDown == 0)
            {
                dashCoolDown = dashCoolDownReset;
                Debug.Log("cooldown time is " + dashCoolDown);
            }
        }

    }
}
