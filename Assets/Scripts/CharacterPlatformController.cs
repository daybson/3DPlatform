using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterPlatformController : MonoBehaviour
{
    private CharacterController charControl;
    public CharacterActionController CharacterActionController;

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


    private void Awake()
    {
        charControl = GetComponent<CharacterController>();
        CharacterActionController = GetComponentInChildren<CharacterActionController>();
    }

    private void Update()
    {
        var input = Input.GetAxisRaw(axisFoward);

        if (Input.GetKeyDown(KeyCode.Space) && charControl.isGrounded)
        {
            CharacterActionController.Animator.SetBool("Jump", true);
            currJumpTime = 0;
            isGoingUp = true;
        }

        if (isGoingUp)
            ProcessJumping();
        else
            ProcessGravity();

        moveY = currVerticalSpeed;
        moveZ = WalkSpeed * input;

        
        CharacterActionController.Animator.SetFloat("Velocity", charControl.velocity.sqrMagnitude);
        if (input != 0)
        {
            transform.forward = input * Vector3.forward;
        }

        charControl.Move(new Vector3(0, moveY, moveZ) * Time.deltaTime);
    }


    private void ProcessJumping()
    {
        currJumpTime += Time.deltaTime;
        currVerticalSpeed += JumpSpeed;

        if (currVerticalSpeed > MaxVerticalSpeed)
            currVerticalSpeed = MaxVerticalSpeed;

        isGoingUp = currJumpTime < JumpTime;
    }


    private void ProcessGravity()
    {
        CharacterActionController.Animator.SetBool("Jump", false);
        currVerticalSpeed -= Gravity;

        if (currVerticalSpeed < -MaxFallSpeed)
            currVerticalSpeed = -MaxFallSpeed;
    }
}
