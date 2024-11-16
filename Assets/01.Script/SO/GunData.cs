using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/GunData")]
public class GunData : ScriptableObject
{
    [Header("GunInfo")]//총 정보
    public AudioClip gunSound;
    public float attackCoolTime;
    public int maxBullet;
    public float rayDistance;

    [Header("ContinuousAttack")]//연사가 되는가
    public bool canContinuousAttack;

    [Header("Burst")]//점사
    public bool isBurst;
    public int burstMany;

    [Header("Recoil")]//반동이 있는가
    public bool haveRecoil;
    public float recoilMin;
    public float recoilMax;

    [Header("MultiAttack")]//샷건처럼 여러개 쏘는가
    public bool canMultiAttack;
    public int minBulletMulti;
    public int maxBulletMulti;
}
