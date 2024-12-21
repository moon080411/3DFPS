using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStorge
{
    private List<GunData> weaponDataList = new List<GunData>();
    private int currentWeaponIndex = -1;

    public int WeaponCount { get => weaponDataList.Count; }

    internal bool AddWeaponData(GunData weaponData)
    {
        if (weaponDataList.Contains(weaponData)) return false;
        weaponDataList.Add(weaponData);
        currentWeaponIndex = WeaponCount - 1;
        return true;
    }

    internal GunData GetCurrentWeapon()
    {
        if (currentWeaponIndex == -1) return null;
        return weaponDataList[currentWeaponIndex];
    }

    internal GunData SwapWeapon()
    {
        if (currentWeaponIndex == -1) return null;
        currentWeaponIndex++;
        if (currentWeaponIndex >= weaponDataList.Count)
        {
            currentWeaponIndex = 0;
        }
        return weaponDataList[currentWeaponIndex];
    }
}
