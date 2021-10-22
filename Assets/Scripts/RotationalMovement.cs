using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalMovement : MonoBehaviour
{
    private float angleY = 1.0f;
    private float speedY = 1.5f;
    private float angleX = 2f;
    public float speedX = 3f;
   
    public Vector3 TurningPlayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerRotation();
      
    }

    private void PlayerRotation()
    {
        angleY += speedY * Input.GetAxis("Mouse Y");
        angleX += speedX * Input.GetAxis("Mouse X");
       
        TurningPlayer = transform.InverseTransformDirection(TurningPlayer);
        TurningPlayer = transform.eulerAngles = new Vector3(0, angleX + angleY, 0);
    }
    
}
