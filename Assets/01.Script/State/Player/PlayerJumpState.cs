using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player agent) : base(agent)
    {
    }
    protected override void EnterState()
    {
        base.EnterState();
        _agent.AniCompo.PlayAnimation(AnimationType.Jump);
        _agent.RbCompo.AddForce(Vector3.up * _agent.DataCompo.jumpPower, ForceMode.Impulse);
    }
    public override void StateUpdate()
    {
        base.StateUpdate();
    }
}
