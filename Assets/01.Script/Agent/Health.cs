using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]AgentData agentData;
    public event Action OnDamaged;
    public event Action OnDie;
    int maxHelth;
    int health;
    
    private void Awake()
    {
        maxHelth = agentData.maxHealth;
        health = maxHelth;
    }
    public void Damaged(int damage)
    {
        health -= damage;
        if(health > 0)
        {
            OnDamaged?.Invoke();
        }
        else
        {
            health = 0;
            OnDie?.Invoke();
        }
    }
}