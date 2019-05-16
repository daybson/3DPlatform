using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Classe abstrata responsável por forçar a implementação dos métodos de um estado sobre os estados filhos
/// </summary>
public abstract class State : MonoBehaviour, IState
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected CharacterController charControl;
    [SerializeField] protected StateController stateControl;
    protected CharacterPlatformController characterPlatformController;

    protected virtual void Awake()
    {
        print("Awake");
        animator = GetComponentInChildren<Animator>() ?? GetComponent<Animator>();
        charControl = GetComponent<CharacterController>();
        stateControl = GetComponent<StateController>();
        characterPlatformController = GetComponent<CharacterPlatformController>();
    }

    public abstract int Type { get; }

    public abstract void OnDisable();

    public abstract void OnEnable();

    public abstract void Update();
}
