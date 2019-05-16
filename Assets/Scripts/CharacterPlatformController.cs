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

        /*

        if (this.stateControl.CurrentState == StateType.JUMP)
        {
            if (!((JumpState)this.stateControl.states[StateType.JUMP]).IsGoingUp)
            {
                this.stateControl.ChangeState(StateType.IDLE);
            }
        }
        else if (this.stateControl.CurrentState != StateType.JUMP)
        {
            ProcessGravity();

            if (Input.GetKeyDown(KeyCode.Space) && charControl.isGrounded)
                this.stateControl.ChangeState(StateType.JUMP);
            else
            {
                if (!((AttackState)this.stateControl.states[StateType.ATTACK]).sword.IsAtacking)
                {
                    if (InputX != 0)
                        this.stateControl.ChangeState(StateType.WALK);
                    else
                        this.stateControl.ChangeState(StateType.IDLE);
                }

                if (Input.GetMouseButtonDown(0))
                    this.stateControl.ChangeState(StateType.ATTACK);
            }
        }
        */
    }


    public void ProcessGravity()
    {
        currVerticalSpeed -= Gravity;

        if (currVerticalSpeed < -MaxFallSpeed)
            currVerticalSpeed = -MaxFallSpeed;

        charControl.Move(new Vector3(0, currVerticalSpeed, 0) * Time.deltaTime);
    }
}
