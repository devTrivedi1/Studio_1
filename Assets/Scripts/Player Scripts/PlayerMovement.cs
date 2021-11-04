using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 targetPosition; 
    public Vector3 lookAtTarget;
    public bool playerClicked; 
    Quaternion playerRot; 
    private int rotSpeed;
    public float moveSpeed;  
    private Vector3 offset = new Vector3(0, 1.5f, 0);

    public Vector3 newPosition; 
    public LayerMask layerMask;

    

    //Transform forceTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonUp(0))
        {
            playerClicked = true;
            SetTargetPosition();
        }
    }


    private void FixedUpdate()
    {
        if (playerClicked)
        {
            Move();
        }

    }
    public void SetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            targetPosition = hit.point;
            //Debug.Log("target pos is " + targetPosition);
            //this.transform.LookAt(targetPosition);
            lookAtTarget = new Vector3(targetPosition.x - transform.position.x, targetPosition.y - transform.position.y,
                targetPosition.z - transform.position.z);
            playerRot = Quaternion.LookRotation(lookAtTarget);

        }
    }
    public void Move()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, playerRot, moveSpeed * Time.deltaTime);
        newPosition = Vector3.MoveTowards(transform.position, targetPosition + offset, moveSpeed * Time.deltaTime);
        transform.position = newPosition;
    }

}
