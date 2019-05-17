using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class RunState : State
{
    public override StateType Type => StateType.Run;

    public override void Update()
    {
        print($"{this.GetType().Name} Update");
        this.characterPlatformController.ProcessGravity();
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
