using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointer : MonoBehaviour
{
   
    // Start is called before the first frame update
    private void OnValidate()
    {
    
    }
   

    // Update is called once per frame
    void Update()
    {
        PlayerShootRay();
    }
    public void PlayerShootRay()
    {
        Vector3 origin = transform.position;
        //Vector3 direction = transform.forward;

        float maxDistance = 40f;
        Vector2 clickedOnScreen = Input.mousePosition;

        Debug.DrawRay(origin, clickedOnScreen * maxDistance);
        Ray ray = new Ray(origin, clickedOnScreen * maxDistance);
        RaycastHit hitInfo;
        var hitSomething = Physics.Raycast(ray, out hitInfo, maxDistance);

        if (hitSomething)
        {
            hitInfo.collider.GetComponent<Renderer>().material.color = Color.green;
        }


    }
}
