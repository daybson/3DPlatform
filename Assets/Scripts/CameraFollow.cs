using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    private Camera cam;
    public Transform Target;

    private Vector3 moveTemp;
    public float speed;
    public float yDiff;
    public float zDiff;

    public float movementThereshold;
    public Vector3 offset;

    //public float SpeedDamp;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {/*
        zDiff = Mathf.Abs(Target.position.z - transform.position.z);
        yDiff = Mathf.Abs(Target.position.y - transform.position.y);

        if (zDiff >= movementThereshold || yDiff >= movementThereshold)
        {
            moveTemp = Target.position;
            moveTemp.x = transform.position.x;

            transform.position = Vector3.MoveTowards(transform.position, moveTemp, speed * Time.smoothDeltaTime);
        }*/

        var desiredPos = Target.position + offset;
        var smooth = Vector3.Lerp(transform.position, desiredPos, speed * Time.deltaTime);
        transform.position = smooth;
        transform.LookAt(Target);
    }

    private void aUpdate()
    {
        /*
        cam.transform.LookAt(Target);

        var z = Mathf.Lerp(transform.position.z, Target.position.z, Time.deltaTime * SpeedDamp);
        var y = Mathf.Lerp(transform.position.y, Target.position.y, Time.deltaTime * SpeedDamp);

        transform.position = new Vector3(transform.position.x, y, z);
        */
    }
}
