using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(IdleState))]
[RequireComponent(typeof(WalkState))]
[RequireComponent(typeof(RunState))]
[RequireComponent(typeof(JumpState))]
[RequireComponent(typeof(AttackState))]
public class StateController : MonoBehaviour
{
    [SerializeField]
    public Dictionary<StateType, State> states = new Dictionary<StateType, State>();

    public StateType CurrentState { get; private set; }

    [SerializeField]
    protected Animator animator;
    public Animator Animator => animator;

    private void Awake()
    {
        this.animator = GetComponentInChildren<Animator>() ?? GetComponent<Animator>();

        this.states.Add(StateType.Idle, GetComponent<IdleState>());
        this.states.Add(StateType.Walk, GetComponent<WalkState>());
        this.states.Add(StateType.Run, GetComponent<RunState>());
        this.states.Add(StateType.Jump, GetComponent<JumpState>());
        this.states.Add(StateType.Attack, GetComponent<AttackState>());

        //Desabilita todos inicialmente
        foreach (var s in this.states.Values)
            s.enabled = false;

        //Inicia em Idle
        this.CurrentState = StateType.Idle;
        this.states[this.CurrentState].enabled = true;
    }

    /// <summary>
    /// Realiza a transição de um estado para o outro, desativando o estado atual e ativando o novo
    /// </summary>
    /// <param name="newStateID">Novo estado para o qual se quer alterar</param>
    public void ChangeState(StateType newStateID)
    {
        if (CurrentState == newStateID)
            return;

        var newState = this.states[newStateID];

        if (!CanChangeTo(newState))
        {
            Debug.LogWarning($"Transition from {this.states[this.CurrentState].GetType().Name} to {newState.GetType().Name} not allowed!");
            return;
        }

        this.states[CurrentState].enabled = false;
        this.CurrentState = newStateID;
        newState.enabled = true;
    }


    /*
     *  IDLE > ATACK > WALK > RUN > JUMP
     *  ATACK > IDLE > WALK > RUN
     *  WALK > RUN > JUMP > ATTACK > IDLE
     *  RUN > WALK > JUMP > ATTACK > IDLE
     *  JUMP > IDLE 
     * */
    /// <summary>
    /// Valia as transições possíveis de estados
    /// </summary>
    /// <param name="newState">Novo estado para o qual se quer alterar</param>
    /// <returns>Transição permitida ou não</returns>
    private bool CanChangeTo(IState newState)
    {
        switch (CurrentState)
        {
            case StateType.Idle:
                return newState.Type == StateType.Attack ||
                       newState.Type == StateType.Walk ||
                       newState.Type == StateType.Run ||
                       newState.Type == StateType.Jump;

            case StateType.Attack:
                return newState.Type == StateType.Idle ||
                       newState.Type == StateType.Walk ||
                       newState.Type == StateType.Run;

            case StateType.Walk:
                return newState.Type == StateType.Attack ||
                       newState.Type == StateType.Run ||
                       newState.Type == StateType.Idle ||
                       newState.Type == StateType.Jump;

            case StateType.Run:
                return newState.Type == StateType.Attack ||
                       newState.Type == StateType.Walk ||
                       newState.Type == StateType.Idle ||
                       newState.Type == StateType.Jump;

            case StateType.Jump:
                return newState.Type == StateType.Idle;

            default:
                return false;
        }
    }
}
