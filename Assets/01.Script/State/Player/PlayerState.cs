using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : State
{
    protected Player _agent;
    public PlayerState(Player agent)
    {
        _agent = agent;
        publicAgent = _agent;
    }
    protected override void EnterState()
    {
        _agent.InputCompo.OnMove += Move;
        _agent.InputCompo.OnJumpKeyEvent += Jump;
    }
    protected override void ExitState()
    {
        _agent.InputCompo.OnMove -= Move;
        _agent.InputCompo.OnJumpKeyEvent -= Jump;
    }
}
