using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override StateType Type => StateType.Idle;

    public override void Update()
    {
        print($"{this.GetType().Name} Update");
        this.characterPlatformController.ProcessGravity();

        //idle -> jump
        if (Input.GetKeyDown(KeyCode.Space) && this.charControl.isGrounded)
            this.stateControl.ChangeState(StateType.Jump);

        //idle -> attack
        if (Input.GetMouseButtonDown(0))
            this.stateControl.ChangeState(StateType.Attack);

        //idle -> walk
        if (CharacterPlatformController.InputX != 0)
            this.stateControl.ChangeState(StateType.Walk);
    }

    public override void OnDisable()
    {
        print($"{this.GetType().Name} Disabled");
    }

    public override void OnEnable()
    {
        print($"{this.GetType().Name} Enabled");
        this.animator.SetFloat("Velocity", 0);
    }
}
