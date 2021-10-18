using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    NavMeshAgent navMesh;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
       Move();
    }

    void Move()
    {
        if(Input.GetMouseButtonUp(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo))
        {   
            navMesh.SetDestination(hitInfo.point);
        }
    }
}
