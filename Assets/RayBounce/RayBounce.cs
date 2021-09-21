using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayBounce : MonoBehaviour
{
    public int RayCount =2 ; // maximum amount of ray bounces
    private void Update()
    {
        // a method that takes in a position and direction vector paramenter
        CastRay(transform.position, transform.forward);
    }

    private void CastRay(Vector3 position, Vector3 direction)
    {
        // loops trough the number of hits or bounces the ray does
        for (int i = 0; i < RayCount; i++)
        {
            //Creates a new ray object that takes in a positon and direction
            Ray ray = new Ray(position, direction);
            RaycastHit hit;

            // this shoots out a raycast from the ray, and stores the hit data in raycastHit variable
            if (Physics.Raycast(ray, out hit, 50, 1))
            {
                // if the raycast hit something draw a line from the start to the position to the hit point
                Debug.DrawLine(position, hit.point, Color.red);

                // stores the hit direction and position.
                // calculates which position to start and what direction to go
                position = hit.point;  //     The impact point in world space where the ray hit the collider.
                direction = hit.normal; // //     The normal of the surface the ray hit.

            }
            else
            {
                Debug.DrawRay(position, direction * 50, Color.blue);
            }
        }


    }
}
