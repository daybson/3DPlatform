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

    private void Awake()
    {
	//Teste camera
        cam = GetComponent<Camera>();
        Target = FindObjectOfType<CharacterController>().transform;
    }

    private void LateUpdate()
    {
        var desiredPos = Target.position + offset;
        var smooth = Vector3.Lerp(transform.position, desiredPos, speed * Time.deltaTime);
        transform.position = smooth;
        transform.LookAt(Target);
    }
}
