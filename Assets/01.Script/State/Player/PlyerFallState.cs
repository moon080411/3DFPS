using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyerFallState : PlayerState
{
    public PlyerFallState(Player agent) : base(agent)
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
