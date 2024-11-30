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
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        nowBullet = myWeapon.clipBullet;
    }
    private void Start()
    {
        input.OnAttackEvent += Attack;
    }
    private void Attack(bool v)
    {
        if (!isReload)
        {
            if (nowBullet > 0)
            {
                if (myWeapon.canContinuous)
                {

                }
                else
                {
                    if (v)
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
                        _animator.Play("Attack"); }
                }
                nowBullet--;
                isAttack = true;
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
        isReload = false;
    }
    public void AttackEnd()
    {
        isAttack = false;
    }
}
