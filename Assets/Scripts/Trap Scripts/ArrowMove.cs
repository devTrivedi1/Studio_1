using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    public int Speed;
    private Rigidbody rb;

    public float outOfBounds;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        ArrowOutOfBounds();
    }
    public void Fire()
    {

        Vector3 firePower = transform.forward * Speed;
        rb.velocity = firePower;

    }
    public void ArrowOutOfBounds()
    {
        if (transform.position.x >= outOfBounds || transform.position.z >= outOfBounds)
        {
            Destroy(gameObject);
        }
    }
}
