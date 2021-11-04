using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowThrough : MonoBehaviour
{
    public Transform followPlayer;
    private Vector3 offSet = new Vector3(0, 25f, -50f);

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = followPlayer.transform.position + offSet;
    }
}
