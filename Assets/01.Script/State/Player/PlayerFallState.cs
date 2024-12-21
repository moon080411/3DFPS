using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFallState : PlayerState
{
    public PlayerFallState(Player agent) : base(agent)
    {
    }
    protected override void EnterState()
    {
        base.EnterState();
        _agent.AniCompo.PlayAnimation(AnimationType.Fall);
    }
    public override void StateUpdate()
    {
        if (_agent.GroundCheckCompo.isGround)
        {
            _agent.TransitionState(StateType.Idle);
        }
    }
}
