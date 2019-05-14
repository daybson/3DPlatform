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
    public abstract int Type { get; }

    public abstract void OnDisable();

    public abstract void OnEnable();

    public abstract void Update();
}
