using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public Rigidbody rb;
    public float dashForce;
   
    public float dashSpeed;
    public float curretDashTimer;
    public float dashTimer;
    //private float dashDirection;

    public bool isDashing;
    public bool hasDashed;
   

    private float dashCoolDown;
    public float dashCoolDownReset;

    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dashCoolDown = dashCoolDownReset;
        curretDashTimer = dashTimer;

        dashForce = 2;
        dashSpeed = 20;
       
        dashTimer = 2f;
        playerMovement = GetComponent<PlayerMovement>();

        isDashing = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        //dashDirection = Input.GetAxis("Horizontal");
        Dash();
        DashReset();
        MaintainDash();
    }
    private void FixedUpdate()
    {
        //Dash();
    }
    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Debug.Log("pressed A");
            Vector3 left = new Vector3(-dashForce, 0, 0);
            isDashing = true;
          
            rb.velocity = Vector3.zero;


            if (isDashing)
            {
                
                //Debug.Log("direction gotten");
                transform.position += transform.TransformDirection (left * dashSpeed);

                

                //Debug.Log("current dash t is " + curretDashTimer);
                

            }


        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 right = new Vector3(dashForce, 0, 0);
            isDashing = true;
            
            rb.velocity = Vector3.zero;

            if (isDashing)
            {
               
                //Debug.Log("direction gotten");
                transform.position += transform.TransformDirection(right * dashSpeed);

               

               
            }

        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Vector3 forwards = new Vector3(0, 0, dashForce);
            isDashing = true;
            
            rb.velocity = Vector3.zero;

            if (isDashing && hasDashed == false)
            {
               
                //Debug.Log("direction gotten");
                transform.position += transform.TransformDirection(forwards * dashSpeed);

                

               
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 backwards = new Vector3(0, 0, -dashForce);
            isDashing = true;
           
            rb.velocity = Vector3.zero;

            if (isDashing)
            {
                
                //Debug.Log("direction gotten");
                transform.position += transform.TransformDirection(backwards * dashSpeed);

               

                
            }

        }
        
    }
    public void DashReset()
    {
       
        if (isDashing)
        {
            curretDashTimer -= Time.deltaTime;
            
        }
        if(curretDashTimer <= 0)
        {
            isDashing = false;
            curretDashTimer = dashTimer;
        }

    }
    public void DashCoolDown()
    {
        if(isDashing == false)
        {

        }
    }
    public void MaintainDash()//Before if you dashed after clicking, you WOULD dash, but then proceed to move again to wherever you clicked. This function solves that.
    {
        if (isDashing)
        {
            playerMovement.enabled = false;
        }

        if (hasDashed && isDashing == false);
        {
            GetComponent<PlayerDash>().enabled = false;
        }
        
        if(isDashing == false)
        {
            playerMovement.enabled = true;
          
        }

    }
}
