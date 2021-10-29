using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalMovement : MonoBehaviour
{

	// step 1 : find where the mouse is
	// step 1.1 get the mouse ps in the real world 

	// step 2 : calculate the relative direction from player to mouse
	//step 3 look in this directrion 
	public Vector3 mousePositionInWorldSpace;
	public Camera camera;
	public Vector3 TurningPlayer;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		HandleInputs();
		PlayerRotation();

	}

	private void HandleInputs()
	{
		mousePositionInWorldSpace = Input.mousePosition;
		var ray = camera.ScreenPointToRay(mousePositionInWorldSpace);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			mousePositionInWorldSpace = hit.point;
			Debug.Log(hit.transform);
		}
	}

	private void PlayerRotation()
	{
		var direction = this.mousePositionInWorldSpace - transform.position;
		direction.y = 0;
		transform.forward = direction;
	}

}
