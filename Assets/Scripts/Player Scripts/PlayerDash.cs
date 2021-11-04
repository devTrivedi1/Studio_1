using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed;
    public float doubleTapTime;

    KeyCode lastKeyCode;
    private float dashCount;
    public float startDashCount;
    private int side;
    // Start is called before the first frame update
    void Start()
    {
        dashCount = startDashCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Dash()
    {
        if(side == 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A)
                {
                    side = 1;
                }
                else
                {
                    doubleTapTime = Time.time;
                }
                lastKeyCode = KeyCode.A;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D)
            {
                side = 2;
            }
            else
            {
                doubleTapTime = Time.time;
            }
            lastKeyCode = KeyCode.D;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.W)
            {
                side = 3;
            }
            else
            {
                doubleTapTime = Time.time;
            }
            lastKeyCode = KeyCode.W;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.S)
            {
                side = 4;
            }
            else
            {
                doubleTapTime = Time.time;
            }
            lastKeyCode = KeyCode.S;
        }
    }
}
