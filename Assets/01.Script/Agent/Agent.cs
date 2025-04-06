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
public abstract class Agent : MonoBehaviour, IHitable
{
    #region component region
    public Rigidbody RbCompo { get; protected set; }
    public AgentAnimation AniCompo { get; protected set; }
    public GroundChecker GroundCheckCompo { get; protected set; }
    [field: SerializeField] public AgentData DataCompo { get; protected set; }
    public Health HealthCompo { get; protected set; }
    [field: SerializeField] public Weapon WeaponCompo { get; private set; }
    #endregion

    protected Dictionary<StateType, State> StateEnum = new Dictionary<StateType, State>();

    public Transform myTra;

    [HideInInspector] private State _currentState;

    public float speed;

    public bool canGun;

    protected virtual void Awake()
    {
        RbCompo = GetComponent<Rigidbody>();
        HealthCompo = GetComponent<Health>();
        AniCompo = GetComponentInChildren<AgentAnimation>();
        GroundCheckCompo = GetComponentInChildren<GroundChecker>();
        myTra = transform;
        speed = DataCompo.speed;
        InitializeState();
    }
    protected virtual void Start()
    {
        TransitionState(StateType.Idle);
    }

    protected virtual void SwitchAttack()
    {
        TransitionState(StateType.Attack);
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
    protected virtual void Attack()
    {
        if (WeaponCompo.Attack())
        {
            AniCompo.PlayAnimation(AnimationType.Attack);
        }
        else if (WeaponCompo.CanReload())
        {
            WeaponCompo.Reload();
            AniCompo.PlayAnimation(AnimationType.Reload);
        }
    }

    public virtual void GetHit(int damage)
    {
        HealthCompo.Damaged(damage);
    }
}
