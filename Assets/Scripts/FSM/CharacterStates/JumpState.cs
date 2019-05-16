using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class JumpState : State
{
    public override int Type => StateType.JUMP;


    public bool IsGoingUp { get; private set; }

    private float currJumpTime;
    public float JumpTime;
    public float JumpSpeed;
    private float currVerticalSpeed;
    public float MaxVerticalSpeed;

    public override void Update()
    {
        print($"{this.GetType().Name} Update");

        currJumpTime += Time.deltaTime;
        currVerticalSpeed += JumpSpeed;

        if (currVerticalSpeed > MaxVerticalSpeed)
            currVerticalSpeed = MaxVerticalSpeed;

        IsGoingUp = currJumpTime < JumpTime;

        charControl.Move(new Vector3(0, currVerticalSpeed, 0) * Time.deltaTime);

        if (!IsGoingUp)
            this.stateControl.ChangeState(StateType.IDLE);
    }

    public override void OnDisable()
    {
        print($"{this.GetType().Name} Disabled");
        animator.SetBool("Jump", false);
    }

    public override void OnEnable()
    {
        print($"{this.GetType().Name} Enabled");

        IsGoingUp = true;
        currJumpTime = 0f;
        animator.SetBool("Jump", true);
    }
}
