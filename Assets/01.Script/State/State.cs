using UnityEngine;
using UnityEngine.Events;

public abstract class State
{
    public UnityEvent OnEnter, OnExit;
    protected Vector2 moveDir;
    public Agent publicAgent;
    public void Enter()
    {
        OnEnter?.Invoke();
        EnterState();
    }
    protected virtual void EnterState()
    {

    }

    public virtual void StateUpdate()
    {
        if (publicAgent.RbCompo.velocity.y < -0.01f)
        {
            publicAgent.TransitionState(StateType.Fall);
        }
    }
    
    protected virtual void Move(Vector2 dir)
    {
        moveDir = dir;
    }
    protected virtual void Jump()
    {
        if (publicAgent.GroundCheckCompo.isGround)
        {
            publicAgent.TransitionState(StateType.Jump);
            publicAgent.GroundCheckCompo.isGround = false;
        }
    }
    public virtual void StateFixedUpdate()
    {

    }

    public void Exit()
    {
        OnExit?.Invoke();
        ExitState();
    }

    protected virtual void ExitState()
    {
    }
}