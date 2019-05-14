using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputController : MonoBehaviour
{
    StateController stateController;

    private void Awake()
    {
        this.stateController = GetComponent<StateController>();
    }

    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var jump = Input.GetKeyDown(KeyCode.Space);

        if (x != 0)
            this.stateController.ChangeState(StateType.WALK);
        if (x == 0)
            this.stateController.ChangeState(StateType.IDLE);
    }
}
