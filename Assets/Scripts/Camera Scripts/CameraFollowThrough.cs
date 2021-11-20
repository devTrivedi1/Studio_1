using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowThrough : MonoBehaviour
{
    public Transform followPlayer;
    [SerializeField]private Vector3 offSet = new Vector3(0, 50, -15);

    void Start()
    {
        followPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = followPlayer.transform.position + offSet;
    }
}
