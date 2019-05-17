using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterPlatformController : MonoBehaviour
{
    private CharacterController charControl;
    public StateController stateControl;

    private readonly string axisFoward = "Horizontal";
    private float moveZ;
    private float moveY;

    public float WalkSpeed;

    public float JumpSpeed;
    public float MaxVerticalSpeed;
    public bool isGoingUp;
    public float JumpTime;
    private float currJumpTime;

    public float currVerticalSpeed;
    public float Gravity;
    public float MaxFallSpeed;

    public static float InputX { get; private set; }

    private void Awake()
    {
        this.charControl = GetComponent<CharacterController>();
        this.stateControl = GetComponentInChildren<StateController>();
    }

    private void Update()
    {
        InputX = Input.GetAxisRaw(axisFoward);
    }


    public void ProcessGravity()
    {
        currVerticalSpeed -= Gravity;

        if (currVerticalSpeed < -MaxFallSpeed)
            currVerticalSpeed = -MaxFallSpeed;

        charControl.Move(new Vector3(0, currVerticalSpeed, 0) * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (charControl.isGrounded)
            if (hit.transform.tag == "Floor")
            {
                transform.SetParent(hit.transform);
            }
    }
}
