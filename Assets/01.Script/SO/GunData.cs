using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/GunData")]
public class GunData : ScriptableObject
{
    [Header("GunInfo")]//총 정보
    public AudioClip gunSound;
    public Sprite weaponInfoSprite;
    public GameObject[] weapon;
    public float attackCoolTime;
    public bool isDouble = false;
    public int clipBullet;
    public int maxBullet;
    public float rayDistance;
    public int damage;

    [Header("ContinuousAttack")]//연사가 되는가
    public bool canContinuous;

    [Header("Burst")]//점사
    public bool isBurst;
    public int burstMany;

    [Header("Recoil")]//반동이 있는가
    public bool haveRecoil;
    public float recoilMin;
    public float recoilMax;

    [Header("MultiAttack")]//샷건처럼 여러개 쏘는가
    public bool canMultiAttack;
    public int bulletMany;

    [Header("ZoomCount")]//줌인이 되는자
    public bool canZoom;
    public float ZoomAmount;
}
