using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 targetPosition; 
    public Vector3 lookAtTarget;
    public bool playerClicked; 
    Quaternion playerRot; 
    public float moveSpeed = 30f;  
    private Vector3 offset = new Vector3(0, 1.5f, 0);

    public Vector3 newPosition; 
    public LayerMask layerMask;

    private Rigidbody rb;
    

    //Transform forceTransform;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
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
            ReleaseDamage();
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
           if(hit.collider.tag == "Obstacle")
           {
               lookAtTarget = Vector3.zero;
           }

        }
        
    }

    
    public void Move()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, playerRot, moveSpeed * Time.deltaTime);
        newPosition = Vector3.MoveTowards(transform.position, targetPosition + offset, moveSpeed * Time.deltaTime);
        transform.position = newPosition;
    }
    public void ReleaseDamage()
    {
        rb.AddExplosionForce(10, new Vector3(10, 10, 10), 10, 1, ForceMode.Impulse);
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            newPosition = Vector3.zero;
        }
    }
}
