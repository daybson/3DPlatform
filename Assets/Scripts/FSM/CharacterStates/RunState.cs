using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class RunState : State
{
    public override int Type => StateType.RUN;

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
