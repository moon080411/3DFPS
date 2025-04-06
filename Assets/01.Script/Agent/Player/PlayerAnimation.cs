using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAnimation : AgentAnimation
{
    public override void PlayAnimation(AnimationType animationType)
    {
        if(AnimationType.Attack == animationType)
        {
            Play("(aiming)_Single_Shot");
        }
        else if (AnimationType.Reload == animationType)
        {
            Play("(aiming)Recharge");
        }
        else
        {
            Play("(aiming)Idle");
        }
        print($"Player do {animationType}");
    }
}
