using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GunData myWeapon;
    [SerializeField]private InputReader input;
    private Animator _animator;
    private GunAttack gunAttack;
    private bool canAttack = true;
    private bool canContinuous = false;
    private float timer = 0;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        gunAttack = transform.GetComponentInParent<GunAttack>();
    }
    private void Start()
    {
        if (myWeapon.canContinuous)
        {
            input.OnAttackEvent += ContinuousAttacks;
        }
        else
        {
            input.OnAttackKeyEvent += TryChangeState;
        }
        _animator.SetInteger("BulletCount", myWeapon.clipBullet);
    }
    private void TryChangeState()
    {
        if (_animator.GetBool("IsReloading") || _animator.GetBool("IsAttacking"))
        {
            return;
        }
        else if(canAttack && _animator.GetInteger("BulletCount") > 0)
        {
            canAttack  = false;
        }
        _animator.SetTrigger("ChangeState");
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
            TryChangeState();
        }
    }
    public void ReloadEnd()
    {
        _animator.SetInteger("BulletCount", BulletReload());
    }

    private int BulletReload()
    {
        return myWeapon.clipBullet;
    }

    public void AttackEnd()
    {
        _animator.SetInteger("BulletCount", _animator.GetInteger("BulletCount") - 1);
    }
    private void OnDestroy()
    {
        if (myWeapon.canContinuous)
        {
            input.OnAttackEvent -= ContinuousAttacks;
        }
        else
        {
            input.OnAttackKeyEvent -= TryChangeState;
        }
    }
    public void Attack()
    {
        gunAttack.Shot(transform.position, transform.forward, myWeapon.rayDistance, myWeapon.damage);
    }
}
