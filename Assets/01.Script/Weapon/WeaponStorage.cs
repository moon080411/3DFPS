using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStorage : MonoBehaviour
{
    [SerializeField] GunData StartGun;
    private List<GunData> haveGuns = new List<GunData>();
    private GunData nowGun;
    private Dictionary<GunData, int> bullet = new Dictionary<GunData, int>();
    private void Awake()
    {
        haveGuns.Add(StartGun);
        NowGunChange(StartGun);
    }
    private void NowGunChange(GunData gun)
    {
        nowGun = gun;
    }
    public void WeaponAdd(GunData gunData)
    {
        if(!haveGuns.Contains(gunData))
        {
            haveGuns.Add(gunData);
            bullet.Add(gunData, gunData.maxBullet);
        }
        else
        {
            bullet[gunData] = Mathf.Clamp(bullet[gunData], 0, gunData.maxBullet);
        }
    }
}
