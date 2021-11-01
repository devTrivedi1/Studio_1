using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaunch : MonoBehaviour
{
    public PlayerMovement playerMovement;
    
    private Rigidbody rb;
    public float dashSpeed;
    public float dashTime;
    float startDashTime;
    float direction;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(direction == 0)
        {
            if (playerMovement.playerClicked && Input.GetMouseButtonUp(0))
            {
                direction = playerMovement.targetPosition.z;

            }
            else
            {
                if(dashTime <= 0)
                {
                    direction = 0;
                    dashTime = startDashTime;
                    rb.velocity = Vector3.zero;
                }
                else
                {
                    dashTime -= Time.deltaTime;
                    if(direction == playerMovement.targetPosition.z)
                    {
                        rb.velocity = playerMovement.newPosition;
                    }
                }
            }
        }
    }
}
