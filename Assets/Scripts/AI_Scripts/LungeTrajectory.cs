using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungeTrajectory : MonoBehaviour
{
    public GameObject pointPrefab;
    public GameObject[] points;

    public int numberOfPoints;
   
    public int force;
    // Start is called before the first frame update
    void Start()
    {
        points = new GameObject[numberOfPoints];

        for(int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(pointPrefab, transform.position, Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < points.Length; i++)
        {
            points[i].transform.position = PointPosition(i * 0.1f);
        }
    }
    private Vector3 PointPosition(float t)
    {
        float pointDirection = 20;
        Vector3 direction = Vector3.forward * pointDirection;
        Vector3 currentPointPos = transform.position + (direction.normalized * force * t) + 0.5f * Physics.gravity * (t * t);
        return currentPointPos;
    }
}
