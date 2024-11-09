using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player agent) : base(agent)
    {
    }
    protected override void EnterState()
    {
        if (Mathf.Abs(moveDir.x) + Mathf.Abs(moveDir.y) > 0.01f)
        {
            _agent.RbCompo.velocity = new Vector3(_agent.RbCompo.velocity.x, 0, _agent.RbCompo.velocity.z);
            _agent.TransitionState(StateType.Move);
        }
        base.EnterState();
        _agent.RbCompo.velocity = Vector3.zero;
        _agent.AniCompo.PlayAnimation(AnimationType.Idle);
    }
    public override void StateUpdate()
    {
        base.StateUpdate();
        if(Mathf.Abs(moveDir.x) + Mathf.Abs(moveDir.y) > 0.01f)
        {
            _agent.TransitionState(StateType.Move);
        }
    }
}
