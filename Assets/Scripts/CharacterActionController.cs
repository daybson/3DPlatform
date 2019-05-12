using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActionController : MonoBehaviour
{
    //Tip: mudar o animationType para Generic
    public Animator Animator;
    Sword sword;

    private void Awake()
    {
        Animator = GetComponentInChildren<Animator>();
        sword = GetComponentInChildren<Sword>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            sword.IsAtacking = true;
            Animator.SetBool("Attack", true);
        }
        else
        {
            Animator.SetBool("Attack", false);
        }
    }

    public void FinishAttack()
    {
        print("finish atack");
        sword.IsAtacking = false;
    }
}
