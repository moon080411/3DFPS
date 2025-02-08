using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentAnimation : MonoBehaviour
{
    protected Animator _animator;
    public UnityEvent OnAnimationAction;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public virtual void PlayAnimation(AnimationType animationType)
    {
        switch (animationType)
        {
            case AnimationType.Idle:
                Play("(aiming)Idle");
                break;
            case AnimationType.Attack:
                Play("(aiming)_Single_Shot");
                break;
            case AnimationType.Move:
                Play("(aiming)Run");
                break;
            case AnimationType.Reload:
                Play("(aiming)Recharge");
                break;
            case AnimationType.Dead:
                Play("(aiming)Dead");
                break;
        }
    }
    public void Play(string name)
    {
        _animator.Play(name);
    }
    public void InvokeAnimationAction()
    {
        OnAnimationAction?.Invoke();
    }
    public Animator GetAnimator()
    {
        return _animator;
    }
}
public enum AnimationType
{
    Idle,
    Move,
    Attack,
    Dead,
    Jump,
    Fall,
    Reload
}