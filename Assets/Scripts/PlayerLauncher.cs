using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLauncher : MonoBehaviour
{
    Rigidbody rb;
    float holdStartTime;
    float maxHoldTime = 3.0f;
    public float speedforce = 100f;
    public PlayerMovement playerMovement;
    int speedBoost = 15;
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            playerMovement.moveSpeed += speedBoost;
        }
        ChargeLimitChecker();

        ChargeRelease();
    }

    private void ChargeRelease()
    {
        if (Input.GetMouseButtonUp(0))
        {


            //float holdDownTime = Time.time - holdStartTime;
            //Launch(HoldDownForce(holdDownTime));
            //StartCoroutine(SpeedBoost());
            playerMovement.Move();
            playerMovement.moveSpeed -= speedBoost;
            Debug.Log("Move speed is " + playerMovement.moveSpeed);

        }
    }

    private void ChargeLimitChecker()
    {
        if (Input.GetMouseButton(0))
        {
            holdStartTime = Time.time;
            Debug.Log("hold time is " + holdStartTime);
            if (holdStartTime >= maxHoldTime)
            {
                holdStartTime = maxHoldTime;
            }

            Debug.Log("Move speed is " + playerMovement.moveSpeed);
        }
    }

    private void Launch(float force)
    {
        /*rb.position = transform.position;
        Vector3 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * -1f;
        rb.velocity = direction * force;*/
        playerMovement.SetTargetPosition();
        //Vector3 pushPower = new Vector3(15, 0, 15);
        //rb.AddForce(pushPower);
      
        playerMovement.moveSpeed += speedBoost;
    }
    private float HoldDownForce(float holdTime)
    {
        float maxForceHoldTime = 3f;
        float holdTimeNormalized = Mathf.Clamp01(holdTime / maxForceHoldTime);
        float force = holdTimeNormalized * speedforce;
        return force;
    }
    //private IEnumerator SpeedBoost()
    //{
        //yield return new WaitForSeconds(3f);
    //}
}
