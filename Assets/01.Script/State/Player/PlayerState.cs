using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : State
{
    protected Player _agent;
    public PlayerState(Player agent)
    {
        _agent = agent;
        publicAgent = agent;
    }
    protected override void EnterState()
    {
        //_agent.InputCompo.OnMove += Move;
        _agent.InputCompo.OnJumpKeyEvent += Jump;
        _agent.InputCompo.OnRunEvent += RunChange;
    }
    protected override void ExitState()
    {
        //_agent.InputCompo.OnMove -= Move;
        _agent.InputCompo.OnJumpKeyEvent -= Jump;
        _agent.InputCompo.OnRunEvent -= RunChange;
    }
    protected virtual void RunChange(bool isPressed)
    {
        if (!_agent.isZoomed)
        {
            if (isPressed)
            {
                publicAgent.speed = _agent.DataCompo.speed * publicAgent.DataCompo.RunSpeed;
            }
            else
            {
                publicAgent.speed = _agent.DataCompo.speed;
            }
        }
        else
        {
            if (isPressed)
            {
                _agent.SettingZoomInout(true);
                publicAgent.speed = _agent.DataCompo.speed * publicAgent.DataCompo.RunSpeed;
            }
        }
    }
}
