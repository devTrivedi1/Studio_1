using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowThrough : MonoBehaviour
{
    public Transform followPlayer;
    private Vector3 offSet = new Vector3(0, 25, -50);

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = followPlayer.transform.position + offSet;
    }
}
