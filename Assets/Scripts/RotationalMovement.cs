using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalMovement : MonoBehaviour
{
    public float angleZ = 1.0f;
    public float speedZ = 1.5f;
    public float angleX = 2f;
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
        angleZ += speedZ * Input.GetAxis("Mouse Y");
        angleX += speedX * Input.GetAxis("Mouse X");
        TurningPlayer = transform.InverseTransformDirection(TurningPlayer);
        TurningPlayer = transform.eulerAngles = new Vector3(0, angleX + angleZ, 0);
    }
}
