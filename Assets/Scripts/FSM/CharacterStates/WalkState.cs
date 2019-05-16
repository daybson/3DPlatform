using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    public override int Type => StateType.WALK;
    public float WalkSpeed;

    public override void Update()
    {
        print($"{this.GetType().Name} Update");

        this.characterPlatformController.ProcessGravity();

        transform.forward = CharacterPlatformController.InputX * Vector3.forward;
        charControl.Move(new Vector3(0, 0, WalkSpeed * CharacterPlatformController.InputX) * Time.deltaTime);

        //walk -> idle
        if (CharacterPlatformController.InputX == 0)
            this.stateControl.ChangeState(StateType.IDLE);

        //walk -> jump
        else if (Input.GetKeyDown(KeyCode.Space) && this.charControl.isGrounded)
            this.stateControl.ChangeState(StateType.JUMP);

        //walk -> attack
        else if (Input.GetMouseButtonDown(0))
            this.stateControl.ChangeState(StateType.ATTACK);

        print("SPACE "+ (Input.GetKeyDown(KeyCode.Space) && this.charControl.isGrounded).ToString());
    }

    public override void OnDisable()
    {
        print($"{this.GetType().Name} Disabled");
    }

    public override void OnEnable()
    {
        print($"{this.GetType().Name} Enabled");

        this.animator.SetFloat("Velocity", 3f);
    }
}
