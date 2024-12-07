using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GunData myWeapon;
    [SerializeField]private InputReader input;
    private bool _attack1 = true;
    private Animator _animator;
    private int nowBullet;
    private bool isReload = false;
    private bool isAttack = false;
    private bool canAttack = true;
    private bool canContinuous = false;
    private float timer = 0;
    private Coroutine coroutine;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        nowBullet = myWeapon.clipBullet;
    }
    private void Start()
    {

        if (myWeapon.canContinuous)
        {
            input.OnAttackEvent += ContinuousAttacks;
        }
        else
        {
            input.OnAttackKeyEvent += Attack;
        }
    }
    private void ContinuousAttacks(bool v)
    {
        canContinuous = v;
    }

    private void Update()
    {
        if (!canAttack)
        {
            timer += Time.deltaTime;
            if(timer > myWeapon.attackCoolTime)
            {
                canAttack = true ;
                timer = 0 ;
            }
        }
        else if(canContinuous)
        {
            Attack();
        }
        else if(!isAttack && !isReload)
        {
            _animator.Play("Idle");
        }
    }
    private void Attack()
    {
        if (!isReload && canAttack&& !isAttack)
        {
            if (nowBullet > 0)
            {
                if (myWeapon.isDouble)
                {
                    if (_attack1)
                    {
                        _attack1 = false;
                    }
                    else
                    {
                        _attack1 = true;
                    }
                }
                _animator.Play("Attack");
                isAttack = true;
                nowBullet--;
                canAttack = false;
            }
            else if (_attack1)
            {
                _animator.Play("Reload");
                isReload = true;
            }
            else
            {
                _attack1 = true;
            }
        }
    }
    public void ReloadEnd()
    {
        nowBullet = myWeapon.clipBullet;
        isReload = false;
    }
    public void AttackEnd()
    {
        isAttack = false;
    }
    private void OnDestroy()
    {
        if (myWeapon.canContinuous)
        {
            input.OnAttackEvent -= ContinuousAttacks;
        }
        else
        {
            input.OnAttackKeyEvent -= Attack;
        }
    }
}
