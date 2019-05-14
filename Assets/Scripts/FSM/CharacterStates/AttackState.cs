using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AttackState : State
{
    public override int Type => StateType.ATTACK;

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
