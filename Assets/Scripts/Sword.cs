using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public int Damage;
    public bool IsAtacking;

    private void OnCollisionEnter(Collision collision)
    {
        print("COllision");
        if (IsAtacking)
            collision.transform.GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
