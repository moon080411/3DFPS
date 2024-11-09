using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public enum StateType
{
    Idle,
    Move,
    Attack,
    Dead,
    Jump,
    Fall
}
public abstract class Agent : MonoBehaviour
{
    #region component region
    public SpriteRenderer SpriteCompo { get; private set; }
    public Rigidbody RbCompo { get; private set; }
    public AgentAnimation AniCompo { get; private set; }
    public GroundChecker GroundCheckCompo { get; private set; }
    #endregion

    protected Dictionary<StateType, State> StateEnum = new Dictionary<StateType, State>();

    [HideInInspector] private State _currentState;

    [field: SerializeField] public AgentData DataCompo { get; protected set; }
    protected virtual void Awake()
    {
        RbCompo = GetComponent<Rigidbody>();
        AniCompo = GetComponentInChildren<AgentAnimation>();
        SpriteCompo = GetComponentInChildren<SpriteRenderer>();
        InitializeState();
    }
    private void Start()
    {
        TransitionState(StateType.Idle);
    }
    public abstract void InitializeState();
    internal void TransitionState(StateType desireState)
    {
        if (_currentState != null)
            _currentState.Exit();
        _currentState = StateEnum[desireState];
        _currentState.Enter();

    }
    private void Update()
    {
        _currentState.StateUpdate();
    }
    private void FixedUpdate()
    {
        _currentState.StateFixedUpdate();
    }
}
