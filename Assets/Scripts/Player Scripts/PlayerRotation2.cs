using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation2 : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
        Vector3 mousePos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse X"));
        transform.LookAt(mousePos);
	}

	// Update is called once per frame
	void Update()
	{
        
        
	}
}
