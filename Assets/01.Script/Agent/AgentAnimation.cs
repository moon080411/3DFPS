using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentAnimation : MonoBehaviour
{
    private Animator _animator;
    public UnityEvent OnAnimationAction;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void PlayAnimation(AnimationType animationType)
    {
        //Play(animationType.ToString());
        print($"Player do {animationType}");
 
    }
    public void Play(string name)
    {
        _animator.Play(name);
    }
    public void InvokeAnimationAction()
    {
        OnAnimationAction?.Invoke();
    }
}
public enum AnimationType
{
    Idle,
    Move,
    Attack,
    Dead,
    Jump,
    Fall
}