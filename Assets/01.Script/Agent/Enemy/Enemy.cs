using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : Agent
{
    protected override void Awake()
    {
        base.Awake();
        HealthCompo.OnDie += Die;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public override void InitializeState()
    {
        foreach (StateType stateType in Enum.GetValues(typeof(StateType)))
        {
            string enumName = stateType.ToString();
            Type t = Type.GetType($"Enemy{enumName}State");
            State state = Activator.CreateInstance(t, new object[] { this }) as State;
            StateEnum.Add(stateType, state);
        }
    }
}
