using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dev, I left in a bunch of Debugs, you can uncomment to see any values you want...
public class PlayerLauncher : MonoBehaviour
{
    Rigidbody rb;
    float holdStartTime;
    //float maxChargeTime = 1.0f;

    public float currentSpeedBoost;
    public float maxSpeedBoost = 50;
    private float speedMultiplier = 100f;//(for the speed boost).
    private float addTheSpeed = 6.5f;
    public float maxSpeed = 150;//(player's speed plus the speed boost).

    private float speedReset = 1.0f;//Time to wait to reset the move speed;

    public PlayerMovement playerMovement;
    private bool playerReachedTarget;
    private Vector3 roomForError = Vector3.one * 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeedBoost = 40f;
        //speedReset = 1.0f;
       

    }

    // Update is called once per frame
    void Update()
    {
        //ChargingUp();//Involved with the MaxChargeTime Function;
        WhileCharging();
        //MaxChargeTime();//Abandoned function, I tried to use this instead of the Coroutine but it did not work.
        StartCoroutine("SpeedBoostDuration");
    }
    private void FixedUpdate()
    {
       /*ChargeRelease();*/
    }

    private void WhileCharging()
    {
        if (Input.GetMouseButton(0))
        {
            currentSpeedBoost += Time.deltaTime * speedMultiplier;//value keeps increasing;
            playerMovement.moveSpeed += currentSpeedBoost * Time.deltaTime * addTheSpeed;//Player speed was increasing way faster than
            //the speed boost, because of += I guess. When I added another Time.DeltaTime on the line above that slowed it down. Try to multiply it by 
            //different floats and see what happens...

            //Debug.Log("Total speed is " + playerMovement.moveSpeed);

            if (currentSpeedBoost > maxSpeedBoost)
            {
                currentSpeedBoost = maxSpeedBoost; //speed boost won't go higher than the maxSpeedBoost;
            }
           

            //Debug.Log("Added speed boost is " + currentSpeedBoost);
            //Debug.Log("Movement speed is " + playerMovement.moveSpeed);
        }
        if (playerMovement.moveSpeed >= maxSpeed)
        {
            playerMovement.moveSpeed = maxSpeed;
        }

    }

    /*private void ChargingUp()
    {
        if (Input.GetMouseButton(0))
        {
            holdStartTime += Time.deltaTime;//keeps going up so long as you are holding the mouse. 

        }

    }*/

/*     private void ChargeRelease()//player only moves when you release left click.
    {
        if (Input.GetMouseButtonUp(0))
        {
            playerMovement.SetTargetPosition();
            playerMovement.Move();
        }
       
        if (transform.position +- roomForError == playerMovement.targetPosition +- roomForError)
        {
            playerReachedTarget = true;
            if (playerReachedTarget)
            {
                //playerMovement.moveSpeed -= currentSpeedBoost;
                Debug.Log("reached the target" + playerReachedTarget);
                //Debug.Log("Final Speed is " + playerMovement.moveSpeed); 
            }
           
        }
    } */
    
    /*public void MaxChargeTime()//The code is correct, it's just being overruled because ChargeRelease(); is constantly called.
    {
        float holdTime = Time.time + holdStartTime;
        if (holdTime > maxChargeTime)
        {
            holdTime = maxChargeTime;
            ChargeRelease();
        }
        // Debug.Log("Hold time is " + holdTime);

    }*/
     public IEnumerator SpeedBoostDuration()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //yield return new WaitUntil(() => playerReachedTarget == true);
            yield return new WaitForSeconds(speedReset);
            currentSpeedBoost = 0;
            playerMovement.moveSpeed = 150f;
        }
        
    }



}
