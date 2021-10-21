using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dev, I left in a bunch of Debugs, you can uncomment to see any values you want...
public class PlayerLauncher : MonoBehaviour
{
    Rigidbody rb;
    float holdStartTime;
    float maxChargeTime = 1.0f;

    public float currentSpeedBoost;
    public float maxSpeedBoost = 50;
    public float speedMultiplier = 1f;//(for the speed boost).
    public float maxSpeed = 130;//(player's speed plus the speed boost).

    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeedBoost = 0;

    }

    // Update is called once per frame
    void Update()
    {
        ChargingUp();
        WhileCharging();
        MaxChargeTime();
    }
    private void FixedUpdate()
    {
        ChargeRelease();
    }

    private void WhileCharging()
    {
        if (Input.GetMouseButton(0))
        {
            currentSpeedBoost += Time.deltaTime * speedMultiplier;//value keeps increasing;
            playerMovement.moveSpeed += currentSpeedBoost;
            Debug.Log("Total speed is " + playerMovement.moveSpeed);

            if (currentSpeedBoost > maxSpeedBoost)
            {
                currentSpeedBoost = maxSpeedBoost;//speed boost won't go higher than the maxSpeedBoost;
            }



            //Debug.Log("Added speed boost is " + currentSpeedBoost);
            //Debug.Log("Movement speed is " + playerMovement.moveSpeed);
        }
    }

    private void ChargingUp()
    {
        if (Input.GetMouseButtonDown(0))
        {
            holdStartTime += Time.deltaTime;//keeps going up so long as you are holding the mouse. 
        }

    }

    private void ChargeRelease()//player only moves when you release left click.
    {
        if (Input.GetMouseButtonUp(0))
        {
            playerMovement.SetTargetPosition();
            playerMovement.Move();

            bool playerReachedTarget = transform.position == playerMovement.newPosition;
            if (playerReachedTarget)
            {

                playerMovement.moveSpeed -= currentSpeedBoost;//Dev I think the problem is here, it should be working, but when
                //you release left click, the player's moveSpeed does not revert back to normal...I think we have to find the right place for this command.
                Debug.Log("Final Speed is " + playerMovement.moveSpeed);
                currentSpeedBoost = 0;
            }

        }

    }
    public void MaxChargeTime()//The code is correct, it's just being overruled because ChargeRelease(); is constantly called.
    {
        float holdTime = Time.time - holdStartTime;
        if (holdTime > maxChargeTime)
        {
            holdTime = maxChargeTime;
            ChargeRelease();
        }
        Debug.Log("Hold time is " + holdTime);

    }




}
