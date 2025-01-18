using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(Player agent) : base(agent)
    {
    }
    protected override void EnterState()
    {
        base.EnterState();
        if (_agent.WeaponCompo.Attack())
        {
            _agent.AniCompo.PlayAnimation(AnimationType.Attack);
        }
        else if (_agent.WeaponCompo.CanReload())
        {
            _agent.WeaponCompo.Reload();
            _agent.AniCompo.PlayAnimation(AnimationType.Reload);
        }
    }
    public override void StateUpdate()
    {
        base.StateUpdate();
    }
}
