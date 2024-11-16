using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        base.StateUpdate();
        if (Mathf.Abs(_agent.InputCompo.movement.x) + Mathf.Abs(_agent.InputCompo.movement.y) <= 0.01f)
        {
            _agent.TransitionState(StateType.Idle);
        }
    }
    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
        Vector3 movement = new Vector3(_agent.InputCompo.movement.x, 0, _agent.InputCompo.movement.y);
        Vector3 myMoveDir = _agent.transform.TransformDirection(movement);
        _agent.RbCompo.velocity = myMoveDir * _agent.DataCompo.speed;
    }
}
