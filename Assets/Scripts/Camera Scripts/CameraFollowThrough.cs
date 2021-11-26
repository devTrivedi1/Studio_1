using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowThrough : MonoBehaviour
{
	public GameObject followPlayer;
	[SerializeField] private Vector3 offSet = new Vector3(0, 50, -15);

	void Start()
	{
		followPlayer = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
        followPlayer = GameObject.FindGameObjectWithTag("Player");
		transform.position = followPlayer.transform.position + offSet;
	}

}
