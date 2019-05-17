using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public Transform sun;
    public Transform earth;
    public float angles = 0;
    public float radius;


    void Update()
    {
        /*
        var vRadius = new Vector3(radius, 0, radius);

        angles++;
        earth.position = 
            (sun.position - vRadius) + Quaternion.Euler(0, angles, 0) * (sun.position + vRadius);

        earth.position += vRadius;
        */

        transform.up = Vector3.Lerp(transform.up, Vector3.up, 2 * Time.deltaTime);
    }
}
