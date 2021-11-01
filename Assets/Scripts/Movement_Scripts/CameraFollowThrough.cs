using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowThrough : MonoBehaviour
{
    public Transform followPlayer;
    public Vector3 offSet;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = followPlayer.transform.position + offSet;
    }
}
