using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed;
    
    void FixedUpdate()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }
}
