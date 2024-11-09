using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : State
{
    protected Enemy _agent;
    public EnemyState(Enemy agent)
    {
        _agent = agent;
        publicAgent = _agent;
    }
}
