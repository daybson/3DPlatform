using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface que determina os métodos necessários de um estado
/// </summary>
public interface IState 
{
    /// <summary>
    /// Tipo do estado definido em StateType
    /// </summary>
    StateType Type { get; }

    /// <summary>
    /// Executado ao entrar no estado
    /// </summary>
    void OnEnable();

    /// <summary>
    /// Executado enquanto o estado estiver ativo
    /// </summary>
    void Update();

    /// <summary>
    /// Executado ao sair do estado
    /// </summary>
    void OnDisable();
}
