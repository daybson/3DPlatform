using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    public override int Type => StateType.WALK;

    public override void Update()
    {
        print($"{this.GetType().Name} Update");
    }

    public override void OnDisable()
    {
        print($"{this.GetType().Name} Disabled");
    }

    public override void OnEnable()
    {
        print($"{this.GetType().Name} Enabled");
    }
}
