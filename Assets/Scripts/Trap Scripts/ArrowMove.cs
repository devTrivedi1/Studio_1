using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    public float outOfBounds;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 30;
       /*  outOfBounds = 30f; */
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
       /*  ArrowOutOfBounds(); */
    }
    public void Fire()
    {
        Vector3 firePower = transform.forward * speed;
        rb.velocity = firePower;
    }
    /* public void ArrowOutOfBounds()
    {
        if (transform.position.x > outOfBounds || transform.position.z > outOfBounds)
        {
            Destroy(gameObject);
        }
    } */
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Wall" || collision.gameObject.tag == "EnemyArrow" || collision.gameObject.tag == "Obstacle")
        {
            Destroy(this.gameObject);
        }
    }
}
