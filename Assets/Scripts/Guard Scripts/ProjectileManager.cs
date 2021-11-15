using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        if (collision.transform.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
