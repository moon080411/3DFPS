using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/GunData")]
public class GunData : ScriptableObject
{
    [Header("GunInfo")]//�� ����
    public AudioClip gunSound;
    public float attackCoolTime;
    public int maxBullet;
    public float rayDistance;

    [Header("ContinuousAttack")]//���簡 �Ǵ°�
    public bool canContinuousAttack;

    [Header("Burst")]//����
    public bool isBurst;
    public int burstMany;

    [Header("Recoil")]//�ݵ��� �ִ°�
    public bool haveRecoil;
    public float recoilMin;
    public float recoilMax;

    [Header("MultiAttack")]//����ó�� ������ ��°�
    public bool canMultiAttack;
    public int minBulletMulti;
    public int maxBulletMulti;
}
