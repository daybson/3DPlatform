using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AttackState : State
{
    public override int Type => StateType.ATTACK;
    public Sword sword;

    protected override void Awake()
    {
        base.Awake();
        this.sword = GetComponentInChildren<Sword>();
    }

    public override void Update()
    {
        print($"{this.GetType().Name} Update");
    }

    public override void OnDisable()
    {
        print($"{this.GetType().Name} Disabled");
        this.animator.SetBool("Attack", false);
        this.sword.IsAtacking = false;
    }

    public override void OnEnable()
    {
        print($"{this.GetType().Name} Enabled");

        this.sword.IsAtacking = true;
        this.animator.SetBool("Attack", true);
    }
}
