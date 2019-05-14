using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IdleState))]
[RequireComponent(typeof(WalkState))]
[RequireComponent(typeof(RunState))]
[RequireComponent(typeof(JumpState))]
[RequireComponent(typeof(AttackState))]
public class StateController : MonoBehaviour
{
    [SerializeField] public List<State> states;
    public int CurrentState { get; private set; }
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;

    private void Awake()
    {
        this.animator = GetComponentInChildren<Animator>() ?? GetComponent<Animator>();

        this.states.Insert(StateType.IDLE,   GetComponent<IdleState>());
        this.states.Insert(StateType.WALK,   GetComponent<WalkState>());
        this.states.Insert(StateType.RUN,    GetComponent<RunState>());
        this.states.Insert(StateType.JUMP,   GetComponent<JumpState>());
        this.states.Insert(StateType.ATTACK, GetComponent<AttackState>());

        //Desabilita todos inicialmente
        states.ForEach(s => s.enabled = false);

        //Inicia em Idle
        this.CurrentState = StateType.IDLE;
        this.states[this.CurrentState].enabled = true;
    }

    /// <summary>
    /// Realiza a transição de um estado para o outro, desativando o estado atual e ativando o novo
    /// </summary>
    /// <param name="newStateType">Novo estado para o qual se quer alterar</param>
    public void ChangeState(int newStateType)
    {
        if (CurrentState == newStateType)
            return;

        var newState = this.states[newStateType];
        if (!CanChangeTo(newState))
        {
            Debug.LogWarning($"Transition from {this.states[this.CurrentState].GetType().Name} to {newState.GetType().Name} not allowed!");
            return;
        }

        this.states[CurrentState].enabled = false;
        this.CurrentState = newState.Type;
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
            case StateType.IDLE:
                return newState.Type == StateType.ATTACK ||
                       newState.Type == StateType.WALK ||
                       newState.Type == StateType.RUN ||
                       newState.Type == StateType.JUMP;

            case StateType.ATTACK:
                return newState.Type == StateType.IDLE ||
                       newState.Type == StateType.WALK ||
                       newState.Type == StateType.RUN;

            case StateType.WALK:
                return newState.Type == StateType.ATTACK ||
                       newState.Type == StateType.RUN ||
                       newState.Type == StateType.IDLE ||
                       newState.Type == StateType.JUMP;

            case StateType.RUN:
                return newState.Type == StateType.ATTACK ||
                       newState.Type == StateType.WALK ||
                       newState.Type == StateType.IDLE ||
                       newState.Type == StateType.JUMP;

            case StateType.JUMP:
                return newState.Type == StateType.IDLE;

            default:
                return false;
        }
    }
}
