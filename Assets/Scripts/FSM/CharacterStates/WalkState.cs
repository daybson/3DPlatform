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
        transform.forward = CharacterPlatformController.InputX * Vector3.forward;
        charControl.Move(new Vector3(0, 0, WalkSpeed * CharacterPlatformController.InputX) * Time.deltaTime);
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
