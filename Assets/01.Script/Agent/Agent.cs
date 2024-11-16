using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

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
    public Rigidbody RbCompo { get; private set; }
    public AgentAnimation AniCompo { get; private set; }
    public GroundChecker GroundCheckCompo { get; private set; }
    [field: SerializeField] public AgentData DataCompo { get; protected set; }
    #endregion

    protected Dictionary<StateType, State> StateEnum = new Dictionary<StateType, State>();

    public Transform myTra;

    [HideInInspector] private State _currentState;

    protected virtual void Awake()
    {
        RbCompo = GetComponent<Rigidbody>();
        AniCompo = GetComponentInChildren<AgentAnimation>();
        GroundCheckCompo = GetComponentInChildren<GroundChecker>();
        myTra = transform;
        InitializeState();
    }
    protected virtual void Start()
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
