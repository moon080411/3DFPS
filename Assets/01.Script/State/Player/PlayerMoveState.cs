using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player agent) : base(agent)
    {

    }
    protected override void EnterState()
    {
        base.EnterState();
        _agent.AniCompo.PlayAnimation(AnimationType.Move);
    }
    public override void StateUpdate()
    {
        if (Mathf.Abs(moveDir.x) + Mathf.Abs(moveDir.y) <= 0.01f)
        {
            _agent.TransitionState(StateType.Idle);
        }
    }
    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
        _agent.RbCompo.velocity = new Vector3(moveDir.x, _agent.RbCompo.velocity.y, moveDir.y) * _agent.DataCompo.speed;
    }
}
