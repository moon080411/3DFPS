 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public GunData myWeapon;
    [SerializeField]private GunAttack gunAttack;
    public int BulletCount { get; private set; }


    private int AllBullet;
    private void Awake()
    {
        gunAttack = transform.GetComponentInParent<GunAttack>();
    }
    private void Start()
    {
        BulletCount = myWeapon.clipBullet;
        AllBullet = myWeapon.maxBullet - myWeapon.clipBullet;
    }
    public bool Attack()
    {
        if(BulletCount > 0)
        {
            gunAttack.Shot(transform.position , transform.forward, myWeapon.rayDistance, myWeapon.damage);
            return true;
        }
        return false;
    }

    public bool CanReload()
    {
        if(AllBullet > 0)
        {
            return true;
        }
        return false;
    }

    public void Reload()
    {
        if (AllBullet - myWeapon.clipBullet >= 0)
        {
            BulletCount = myWeapon.clipBullet;
            AllBullet -= myWeapon.clipBullet;
        }
        else
        {
            BulletCount = AllBullet;
            AllBullet = 0;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(new Ray(transform.position, transform.forward ));
        Gizmos.color = Color.white;
    }
}
