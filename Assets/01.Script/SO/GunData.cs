using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/GunData")]
public class GunData : ScriptableObject
{
    [Header("GunInfo")]//�� ����
    public AudioClip gunSound;
    public Sprite weaponInfoSprite;
    public GameObject[] weapon;
    public float attackCoolTime;
    public bool isDouble = false;
    public int clipBullet;
    public int maxBullet;
    public float rayDistance;
    public int damage;

    [Header("ContinuousAttack")]//���簡 �Ǵ°�
    public bool canContinuous;

    [Header("Burst")]//����
    public bool isBurst;
    public int burstMany;

    [Header("Recoil")]//�ݵ��� �ִ°�
    public bool haveRecoil;
    public float recoilMin;
    public float recoilMax;

    [Header("MultiAttack")]//����ó�� ������ ��°�
    public bool canMultiAttack;
    public int bulletMany;

    [Header("ZoomCount")]//������ �Ǵ���
    public bool canZoom;
    public float ZoomAmount;
}
