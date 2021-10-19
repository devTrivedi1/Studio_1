using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]


public class Movement : MonoBehaviour
{
    public float speed;

    Vector3 targetPos;
    bool isMoving = false;
   
   
    private void Start()
    {
       
    }
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            TargetPosition();
            Debug.Log("Left click enabled");
        }
        if (isMoving)
        {
            Move();
        }

    }

    void TargetPosition()
    {
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.y = transform.position.y;
        isMoving = true;
        Debug.Log("TargetPosition");
    }

    void Move()
    {

       
        if (transform.position == targetPos)
        {
            isMoving = false;
            Debug.Log("Move Function");
        }
    }
}
