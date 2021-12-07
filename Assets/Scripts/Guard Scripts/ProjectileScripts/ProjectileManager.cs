using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public GameObject patrollingGuard;
    // Start is called before the first frame update
    void Start()
    {
        patrollingGuard = GameObject.FindGameObjectWithTag("PatrollingGuard");
        Physics.IgnoreCollision(this.GetComponent<Collider>(), patrollingGuard.GetComponent<Collider>());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Wall" || collision.transform.tag == "OutOfBounds" || collision.transform.tag == "Obstacle")
        {
            Destroy(this.gameObject, 0.5f);
        }
        if(collision.transform.tag == "Player")
        {
            Destroy(this.gameObject);
        }
      
       
    }
}
