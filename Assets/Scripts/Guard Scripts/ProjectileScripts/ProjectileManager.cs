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

    void OnTriggerEnter(Collider other)
    {
         if (other.transform.tag == "Wall" || other.transform.tag == "OutOfBounds" || other.transform.tag == "Obstacle")
        {
            Destroy(this.gameObject, 0.5f);
        }
        if(other.transform.tag == "Player")
        {
            Destroy(this.gameObject);
        }
      
    }
}
